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
            //lives = 3;
            Debug.Log("If in Lives has gone through");
        }

        livesText = GetComponent<Text>();
        Debug.Log("Text GetComponent has gone through");
    }

    private void Update()
    {
        livesText.text = PlayerController.playerLives.ToString();
    }
}
