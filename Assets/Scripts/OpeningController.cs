using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpeningController : MonoBehaviour
{
    public float xSpeed;
    public float direction;
    public Vector3 openMovemet;
    private bool isOpening = true;
    private bool isEnding = false;
    public float targetTime;
    private GameObject textEndingContinue;
    private GameObject PlayerShip;
    private GameObject MotherShip_1;
    private GameObject[] enemies;
    private Input getKey;
    private Input getPreKey;

    // Start is called before the first frame update
    void Start()
    {
        xSpeed = 1.0f;
        direction = 0;
        targetTime = 1.5f;
        textEndingContinue = GameObject.Find("txtContinue");
        if (textEndingContinue)
        {
            Debug.Log(textEndingContinue.name);
        }
        else
        {
            Debug.Log("No game object called textEndingContinue found");
        }

        PlayerShip = GameObject.Find("PlayerShip");
        MotherShip_1 = GameObject.Find("MotherShip_1");
        enemies = GameObject.FindGameObjectsWithTag("enemies");

    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;
        if (isOpening) {
            //textEndingContinue.SetActive(false);
            if (targetTime <= 0.0f) {
                xSpeed += 0.05f;
                if (this.gameObject.name.Equals("OpenLeft")) {
                    if (this.gameObject.transform.position.x <= -15) {
                        direction = 0;
                    }else
                        direction = -1;
                }
                else if (this.gameObject.name.Equals("OpenRight"))
                {
                    if (this.gameObject.transform.position.x >= 15)
                    {
                        direction = 0;
                    }
                    else
                        direction = 1;
                }
                openMovemet = new Vector3(xSpeed * direction * Time.deltaTime, 0);
                transform.Translate(openMovemet, Space.World);
            }
        }

        if (isEnding) {
            if (targetTime <= 0.0f)
            {
                xSpeed += 0.05f;
                if (this.gameObject.name.Equals("OpenLeft"))
                {
                    if (this.gameObject.transform.position.x >=-5)
                    {
                        direction = 0;
                    }
                    else
                        direction = 1;
                }
                else if (this.gameObject.name.Equals("OpenRight"))
                {
                    if (this.gameObject.transform.position.x <=5)
                    {
                        direction = 0;
                    }
                    else
                        direction = -1;
                }
                openMovemet = new Vector3(xSpeed * direction * Time.deltaTime, 0);
                transform.Translate(openMovemet, Space.World);
            }

            if (Input.GetKeyDown(KeyCode.Y))
            {
                textEndingContinue.GetComponent<Text>().text = "";
                this.RestartEvent();
            }
            else if (Input.GetKeyDown(KeyCode.N)) {
                SceneManager.LoadScene(0);

            }
        }
    }

    private void OnBecameInvisible()
    {
        try
        {
            PlayerShip.GetComponent<PlayerShipController>().enabled = true;
            MotherShip_1.GetComponent<MotherShip1Controller>().enabled = true;
            foreach (GameObject gameObject in enemies)
            {
                gameObject.GetComponent<ChildrenShipController>().enabled = true;
            }

            isOpening = false;
        }
        catch {
            Debug.Log("UnNormal Quit Game!");
        }
    }

    public void EndingEvent() {
        textEndingContinue.SetActive(true);
        if (textEndingContinue)
        {
            Debug.Log(textEndingContinue.name);
        }
        else
        {
            Debug.Log("No game object called textEndingContinue found");
        }
        if(GameObject.Find("txtNumEnemies").GetComponent<NumEnmiesDisplay>().numEnoemies != 0 && GameObject.Find("GameStateHUD").GetComponent<GameState>().playerLifes == 0) { 
            textEndingContinue.GetComponent<NumEnmiesDisplay>().isEnd = true;
            textEndingContinue.GetComponent<NumEnmiesDisplay>().isStart = false;
            textEndingContinue.GetComponent<NumEnmiesDisplay>().continueTimer = 22;
        }
        isEnding = true;
        isOpening = false;
        targetTime = 1f;
        xSpeed = 0;
        //Invoke()
    }


    public void RestartEvent()
    {
        if(GameObject.Find("GameStateHUD").GetComponent<GameState>().playerLifes == 0) { 
            textEndingContinue.GetComponent<NumEnmiesDisplay>().isEnd = false;
            textEndingContinue.GetComponent<NumEnmiesDisplay>().isStart = false;
            textEndingContinue.SetActive(false);
            if (textEndingContinue)
            {
                Debug.Log(textEndingContinue.name);
            }
            else
            {
                Debug.Log("No game object called textEndingContinue found");
            }
            GameObject.Find("GameStateHUD").GetComponent<GameState>().playerLifes = 3;
            PlayerShip.GetComponent<PlayerShipController>().reBorn = true; ;
            PlayerShip.GetComponent<PlayerShipController>().enabled = true;
            PlayerShip.GetComponent<PlayerShipController>().allowXMovement = true;
            GameObject.Find("PlayerLife").GetComponent<PlayerLife>().ResetLife();
        }
        isEnding = false;
        isOpening = true;
        targetTime = 1f;
        xSpeed = 0;
        //Invoke()
    }
}
