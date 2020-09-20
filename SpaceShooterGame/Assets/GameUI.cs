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
        Time.timeScale = 0;
        // Toggle visibility of text?
        // Change to a different scene?
        //GetComponent<Text>
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenuScene");
    }
}
