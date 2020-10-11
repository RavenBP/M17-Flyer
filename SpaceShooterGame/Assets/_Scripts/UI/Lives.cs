using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour
{
    Text livesText;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            PlayerController.playerLives = 3; // Reset player lives
        }

        livesText = GetComponent<Text>();
    }

    private void Update()
    {
        livesText.text = PlayerController.playerLives.ToString(); // Update text on screen 
    }
}
