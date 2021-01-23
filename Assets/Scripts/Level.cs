using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float gameOverDelay = 1f;
    public void LoadGameOver()
    {
        Invoke("End", gameOverDelay);
    }

    private void End()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void LoadGameScene()
    {
        FindObjectOfType<GameSession>().ResetGameSession();
        SceneManager.LoadScene("Game");
    }
    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
