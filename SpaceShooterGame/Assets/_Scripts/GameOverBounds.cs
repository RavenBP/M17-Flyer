using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverBounds : MonoBehaviour
{
    BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController.playerLives -= 1; // Decrement player lives

            if (PlayerController.playerLives < 0) // Player has lost all lives
            {
                SceneManager.LoadScene("GameOverScene"); // Load GameOverScene
            }

            Debug.Log("Triggered by Player");
        }
        else if (collision.tag == "Bullet")
        {
            Debug.Log("Triggered by Bullet");
        }
    }
}
