using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelTwoOpeningWall : MonoBehaviour
{
    public float xSpeed;
    public float direction;
    public Vector3 openMovemet;
    private bool isOpening = true;
    private bool isEnding = false;
    public float targetTime;
    private GameObject textEndingContinue;
    private GameObject PlayerShip;
    private GameObject MotherNest;
    private GameObject MotherShip1L2;
    private GameObject[] enemies;
    private Input getKey;
    private Input getPreKey;
    private bool GameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        xSpeed = 1.0f;
        direction = 0;
        targetTime = 1.5f;
        textEndingContinue = GameObject.Find("txtContinueLevel2");
        if (textEndingContinue)
        {
            Debug.Log(textEndingContinue.name);
        }
        else
        {
            Debug.Log("No game object called textEndingContinue found");
        }

        PlayerShip = GameObject.Find("PlayerShip_L2");
        MotherNest = GameObject.Find("EnemyMotherNest");
        MotherShip1L2 = GameObject.Find("MotherShip_2");
        enemies = GameObject.FindGameObjectsWithTag("enemies");
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;
        if (isOpening)
        {
            //textEndingContinue.SetActive(false);
            if (targetTime <= 0.0f)
            {
                xSpeed += 0.05f;
                if (this.gameObject.name.Equals("OpenLeftLevelTwo"))
                {
                    if (this.gameObject.transform.position.x <= -15)
                    {
                        direction = 0;
                    }
                    else
                        direction = -1;
                }
                else if (this.gameObject.name.Equals("OpenRightLevelTwo"))
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
        if (isEnding)
        {
            if (targetTime <= 0.0f)
            {
                xSpeed += 0.05f;
                if (this.gameObject.name.Equals("OpenLeftLevelTwo"))
                {
                    if (this.gameObject.transform.position.x >= -5)
                    {
                        direction = 0;
                    }
                    else
                        direction = 1;
                }
                else if (this.gameObject.name.Equals("OpenRightLevelTwo"))
                {
                    if (this.gameObject.transform.position.x <= 5)
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
            else if (Input.GetKeyDown(KeyCode.N))
            {
                SceneManager.LoadScene(0);

            }

            if (GameOver) {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    SceneManager.LoadScene(0);
                }
            }
        }
    }

    private void OnBecameInvisible()
    {
        try
        {
            //PlayerShip.GetComponent<PlayerShipController_L2>().enabled = true;
            MotherShip1L2.GetComponent<MotherShip1Controller>().xSpeed = 4;
            MotherShip1L2.GetComponent<MotherShip1Controller>().enabled = true;
            foreach (GameObject gameObject in enemies)
            {
                gameObject.GetComponent<ChildrenShipController>().upperRandomRange = 800;
                gameObject.GetComponent<ChildrenShipController>().enabled = true;
            }
            isOpening = false;
    }
        catch
        {
            Debug.Log("UnNormal Quit Game!");
        }
    }

    public void EndingEvent()
    {
        textEndingContinue.SetActive(true);
        if (textEndingContinue)
        {
            Debug.Log(textEndingContinue.name);
        }
        else
        {
            Debug.Log("No game object called textEndingContinue found");
        }
        if (GameObject.Find("GameStateHUD").GetComponent<GameState>().playerLifes == 0)
        {
            textEndingContinue.GetComponent<MsgDisplay_Level2>().isEnd = true;
            textEndingContinue.GetComponent<MsgDisplay_Level2>().isStart = false;
            textEndingContinue.GetComponent<MsgDisplay_Level2>().continueTimer = 22;
        }
        else {
            textEndingContinue.GetComponent<Text>().text = "End!\nThanks Play!\n\'Enter\' return Menu!";
            GameOver = true;
        }
        isEnding = true;
        isOpening = false;
        targetTime = 1f;
        xSpeed = 0;
        //Invoke()
    }

    public void RestartEvent()
    {
        if (GameObject.Find("GameStateHUD").GetComponent<GameState>().playerLifes == 0)
        {
            textEndingContinue.GetComponent<MsgDisplay_Level2>().isEnd = false;
            textEndingContinue.GetComponent<MsgDisplay_Level2>().isStart = false;
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
            PlayerShip.GetComponent<PlayerShipController_L2>().reBorn = true; ;
            PlayerShip.GetComponent<PlayerShipController_L2>().enabled = true;
            PlayerShip.GetComponent<PlayerShipController_L2>().allowXMovement = true;
            PlayerShip.GetComponent<PlayerShipController_L2>().allowYMovement = true;
            GameObject.Find("PlayerLifeLevelTwo").GetComponent<PlayerLife>().ResetLife();
        }
        isEnding = false;
        isOpening = true;
        targetTime = 1f;
        xSpeed = 0;
        //Invoke()
    }
}
