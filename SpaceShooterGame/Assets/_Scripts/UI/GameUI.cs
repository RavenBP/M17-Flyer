using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public GameObject basePanel; // Used for main UI
    public GameObject overlayPanel1; // Used for first optional panel
    public GameObject overlayPanel2; // Used for second optional panel

    private bool creditsDisplayed;
    private bool controlsDisplayed;
    private bool gamePaused;

    ////////////////////////////////////// Used by MainMenuScene
    public void PlayGame() // Also used by GameOverScene
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ControlsButton()
    {
        if (controlsDisplayed == false)
        {
            controlsDisplayed = true;
            basePanel.SetActive(false);
            overlayPanel1.SetActive(true);
        }
        else if (controlsDisplayed == true)
        {
            controlsDisplayed = false;
            overlayPanel1.SetActive(false);
            basePanel.SetActive(true);
        }
    }

    public void CreditsButton()
    {
        if (creditsDisplayed == false)
        {
            creditsDisplayed = true;
            basePanel.SetActive(false);
            overlayPanel2.SetActive(true);
        }
        else if (creditsDisplayed == true)
        {
            creditsDisplayed = false;
            overlayPanel2.SetActive(false);
            basePanel.SetActive(true);
        }
    }

    ////////////////////////////////////// Used by GameScene
    public void PauseGame()
    {
        if (gamePaused == false)
        {
            Time.timeScale = 0;
            gamePaused = true;
            basePanel.SetActive(false);
            overlayPanel1.SetActive(true);
        }
        else if (gamePaused == true)
        {
            Time.timeScale = 1;
            gamePaused = false;
            overlayPanel1.SetActive(false);
            basePanel.SetActive(true);
        }
    }

    public void ReturnToMainMenu() // Also used by GameOverScene
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenuScene");
    }

    ////////////////////////////////////// Temporary buttons
    public void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public void IncreaseScore()
    {
        Score.scoreValue += 100;
    }
}
