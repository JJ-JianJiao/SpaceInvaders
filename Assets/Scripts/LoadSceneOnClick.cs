using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadSceneOnClick : MonoBehaviour
{
    GameObject gameState;
    // Start is called before the first frame update
    void Start()
    {
        gameState = GameObject.Find("GameStateHUD");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadSceneByIndex(int sceneIndex)
    {
        gameState.GetComponent<GameState>().playerLifes = 3;
        gameState.GetComponent<GameState>().PlayerhighestScore = gameState.GetComponent<GameState>().PlayerhighestScore > gameState.GetComponent<GameState>().Playerscore ? gameState.GetComponent<GameState>().PlayerhighestScore : gameState.GetComponent<GameState>().Playerscore;
        gameState.GetComponent<GameState>().Playerscore = 0;
        SceneManager.LoadScene(sceneIndex);

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
