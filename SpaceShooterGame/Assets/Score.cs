using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Score : MonoBehaviour
{
    public static int scoreValue = 0;
    Text scoreText;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "GameScene") // Currently the score cannot be shown in the pause screen as the Score text within the PausePanel will call Start(), resetting the score...
        {
            scoreValue = 0;
        }

        scoreText = GetComponent<Text>();
    }

    private void Update()
    {
        scoreText.text = "Score: " + scoreValue;
    }
}
