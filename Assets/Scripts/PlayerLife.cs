using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public GameObject Life;
    private GameObject GameState;
    public int PlayerLifes;
    Vector3 startposition;
    Vector3 movePosition;
    // Start is called before the first frame update
    void Start()
    {
        GameState = GameObject.Find("GameStateHUD");
        startposition = new Vector3(-8, -4.0f, 90);
        movePosition = new Vector3(0.6f, 0, 0);
        ResetLife();
        //PlayerLifes = 3;
        //PlayerLifes = GameObject.Find("GameStateHUD").GetComponent<GameState>().playerLifes;
        //for (int i = 0; i < PlayerLifes; i++)
        //{
        //    GameObject life = Instantiate(Life);
        //    life.transform.position += (startposition + movePosition * i);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState)
        {
            PlayerLifes = GameState.GetComponent<GameState>().playerLifes;
        }
        else {
            PlayerLifes = 3;
        }
        //PlayerLifes = GameObject.Find("GameStateHUD").GetComponent<GameState>().playerLifes;
        //for (int i = 0; i < PlayerLifes; i++)
        //{
        //    GameObject life = Instantiate(Life);
        //    life.transform.position += (startposition + movePosition * i);
        //}
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.2f);
    }

    public void DestroyLife() {
        GameObject[] gameObjects  = GameObject.FindGameObjectsWithTag("PlayerLifes");
        if(gameObjects.Length >= 1) { 
            Destroy(gameObjects[gameObjects.Length - 1]);
            if (GameState) { 
                GameState.GetComponent<GameState>().playerLifes--;
            }
        }
        //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShipController>().enabled = true;
    }

    public void ResetLife() {
        if (GameState)
        {
            PlayerLifes = GameObject.Find("GameStateHUD").GetComponent<GameState>().playerLifes;
        }
        else {
            PlayerLifes = 3;
        }
        for (int i = 0; i < PlayerLifes; i++)
        {
            GameObject life = Instantiate(Life);
            life.transform.position += (startposition + movePosition * i);
        }
    }

}
