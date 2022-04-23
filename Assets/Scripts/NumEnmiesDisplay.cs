using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NumEnmiesDisplay : MonoBehaviour
{
    public int numEnoemies;
    private int playerScore;
    private int playerHighestScore;
    private bool isWinLevelOne = false;
    public float continueTimer = 20;
    public float startMenuTimer = 3;
    private string continueNumStr;
    public bool isStart = true;
    public bool isEnd = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.name.Equals("txtNumEnemies")) { 
            numEnoemies = GameObject.FindGameObjectsWithTag("enemies").Length;
            this.GetComponent<Text>().text = "Enemies: " + numEnoemies.ToString();
            if (numEnoemies == 0 && !isWinLevelOne) {
                isWinLevelOne = true;
                GameObject.Find("PlayerShip").GetComponent<PlayerShipController>().WinThisLevel();
            }
        }
        if (this.name.Equals("PlayScores"))
        {
            var gameStateHUD = GameObject.Find("GameStateHUD");
            if (gameStateHUD)
            {
                playerScore = gameStateHUD.GetComponent<GameState>().Playerscore;

                playerHighestScore = GameObject.Find("GameStateHUD").GetComponent<GameState>().PlayerhighestScore;
                this.GetComponent<Text>().text = "Score: " + playerScore.ToString() + "\nHighest Score: " + playerHighestScore.ToString();
            }
        }
        if (this.name.Equals("txtContinue"))
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
                    this.GetComponent<Text>().text = "Level One";

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
    }
}
