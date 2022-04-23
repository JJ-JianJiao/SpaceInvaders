using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MsgDisplay_Level2 : MonoBehaviour
{
    public int numEnoemies;
    private int playerScore;
    private int playerHighestScore;
    private bool isWinLevelTwo = false;
    public float continueTimer = 20;
    public float startMenuTimer = 3;
    private string continueNumStr;
    public bool isStart = true;
    public bool isEnd = false;
    private bool activeBoss = false;

    GameObject gameState;
    GameObject Level2_MotherNest;
    GameObject Boss;
    GameObject MotherShip1L2;
    // Start is called before the first frame update
    void Start()
    {
        gameState = GameObject.Find("GameStateHUD");
        Level2_MotherNest = GameObject.Find("EnemyMotherNest");
        Boss = GameObject.Find("LevelTwoBoss");
        MotherShip1L2 = GameObject.Find("MotherShip_2");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.name.Equals("txtNumEnemies_L2"))
        {
            numEnoemies = GameObject.FindGameObjectsWithTag("enemies").Length;
            numEnoemies += GameObject.FindGameObjectsWithTag("Boss").Length;
            this.GetComponent<Text>().text = "Enemies: " + numEnoemies.ToString();
        }

        if (this.name.Equals("PlayScores_L2"))
        {
            if (gameState)
            {
                playerScore = gameState.GetComponent<GameState>().Playerscore;
                playerHighestScore = gameState.GetComponent<GameState>().PlayerhighestScore;
            }
            else {
                playerScore = -1;
                playerHighestScore = -1;
            }
            string strScore = playerScore != -1 ? playerScore.ToString() : "null";
            string strHighScore = playerHighestScore != -1 ? playerHighestScore.ToString() : "null";
            this.GetComponent<Text>().text = "Score: " + strScore + "\nHighest Score: " + strHighScore;
        }
        if (this.name.Equals("txtContinueLevel2"))
        {
            if (isEnd && !isStart)
            {
                continueTimer -= Time.deltaTime;
                //this.gameObject.SetActive(false);
                if (continueTimer >= 23)
                {
                    this.GetComponent<Text>().text = ""; ;
                }
                else if (continueTimer >= 20)
                {
                    continueNumStr = "9";
                    this.GetComponent<Text>().text = "Continue: \n" + continueNumStr + "\nY/N ?";
                }
                else if (continueTimer >= 18)
                {
                    continueNumStr = "8";
                    this.GetComponent<Text>().text = "Continue: \n" + continueNumStr + "\nY/N ?";
                }
                else if (continueTimer >= 16)
                {
                    continueNumStr = "7";
                    this.GetComponent<Text>().text = "Continue: \n" + continueNumStr + "\nY/N ?";
                }
                else if (continueTimer >= 14)
                {
                    continueNumStr = "6";
                    this.GetComponent<Text>().text = "Continue: \n" + continueNumStr + "\nY/N ?";
                }
                else if (continueTimer >= 12)
                {
                    continueNumStr = "5";
                    this.GetComponent<Text>().text = "Continue: \n" + continueNumStr + "\nY/N ?";
                }
                else if (continueTimer >= 10)
                {
                    continueNumStr = "4";
                    this.GetComponent<Text>().text = "Continue: \n" + continueNumStr + "\nY/N ?";
                }
                else if (continueTimer >= 8)
                {
                    continueNumStr = "3";
                    this.GetComponent<Text>().text = "Continue: \n" + continueNumStr + "\nY/N ?";
                }
                else if (continueTimer >= 6)
                {
                    continueNumStr = "2";
                    this.GetComponent<Text>().text = "Continue: \n" + continueNumStr + "\nY/N ?";
                }
                else if (continueTimer >= 4)
                {
                    continueNumStr = "1";
                    this.GetComponent<Text>().text = "Continue: \n" + continueNumStr + "\nY/N ?";
                }
                else
                {
                    Debug.Log("Return SceneOne");
                    SceneManager.LoadScene("StartMenu");
                }

            }
            else if (isStart && !isEnd)
            {
                startMenuTimer -= Time.deltaTime;
                if (startMenuTimer >= 0)
                {
                    this.GetComponent<Text>().text = "Level Two";

                }
                else
                {
                    isStart = false;
                    isEnd = false;
                    this.GetComponent<Text>().text = "";
                    this.gameObject.SetActive(false);
                }
            }
        }
        if (gameState) {
            if (!MotherShip1L2) {
                Level2_MotherNest.SetActive(true);
                Level2_MotherNest.GetComponent<MotherShip2Controller>().enabled = true;
                if (gameState.GetComponent<GameState>().Playerscore > 1500) {
                    if (Level2_MotherNest) {
                        Level2_MotherNest.gameObject.SetActive(false);
                        if (!activeBoss) {
                            if (Boss)
                            {
                                Boss.gameObject.SetActive(true);
                                activeBoss = true;
                            }
                        }
                    }
                }
            }
        }
        if (!Boss && !isWinLevelTwo) {
            isWinLevelTwo = true;
            GameObject.Find("PlayerShip_L2").GetComponent<PlayerShipController_L2>().WinThisLevel();
        }
    }
}   
