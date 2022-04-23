using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public int playerLifes;
    public int Playerscore;
    public int PlayerhighestScore;

    //public float reBornShipLifeTimer = 0;
    //private float reBornShipLifeCount = 1.0f;
    //public bool reBorn = false;

    private void Awake()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("GameState");
        if (gameObjects.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else {
            DontDestroyOnLoad(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playerLifes = 3;
        Playerscore = 0;
        PlayerhighestScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //reBornShipLifeTimer += Time.deltaTime;

        //if (reBorn && reBornShipLifeTimer >= reBornShipLifeCount) {
        //    GameObject.Find("PlayerShip").GetComponent<PlayerShipController>().ResetPlayer();
        //    reBorn = false;
        //}

        Debug.Log("PlayerLifes:" + playerLifes.ToString());
    }

    public void ChangePlayerLifes(int changeLife) {
        this.playerLifes += changeLife;
    }

    public void UpdatePlayerScores(int changeScore) {
        this.Playerscore += changeScore;
    }

    public void ResetHUD() {
        this.playerLifes = 3;
    }
}
