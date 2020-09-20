using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    private bool gamePaused;

    public void PauseGame()
    {
        if (gamePaused == false)
        {
            Time.timeScale = 0;
            gamePaused = true;
        }
        else if (gamePaused == true)
        {
            Time.timeScale = 1;
            gamePaused = false;
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        // Toggle visibility of text?
        // Change to a different scene?
    }
}
