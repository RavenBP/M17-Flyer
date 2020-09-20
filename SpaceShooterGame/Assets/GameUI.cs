using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public GameObject panel;

    private bool gamePaused;

    public void PauseGame()
    {
        if (gamePaused == false)
        {
            Time.timeScale = 0;
            gamePaused = true;
            panel.SetActive(true);
        }
        else if (gamePaused == true)
        {
            Time.timeScale = 1;
            gamePaused = false;
            panel.SetActive(false);
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenuScene");
    }
}
