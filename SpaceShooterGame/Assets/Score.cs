using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static int scoreValue = 0;
    Text scoreText;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
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
