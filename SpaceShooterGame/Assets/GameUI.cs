using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour // Ideally this could be merged with the other UI scripts so all of the functions exist inside of one script...
{
    public GameObject basePanel;
    public GameObject overlayPanel;

    private bool gamePaused;

    public void PauseGame()
    {
        if (gamePaused == false)
        {
            Time.timeScale = 0;
            gamePaused = true;
            basePanel.SetActive(false);
            overlayPanel.SetActive(true);
        }
        else if (gamePaused == true)
        {
            Time.timeScale = 1;
            gamePaused = false;
            overlayPanel.SetActive(false);
            basePanel.SetActive(true);
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

    public void IncreaseScore()
    {
        Score.scoreValue += 100;
    }
}
