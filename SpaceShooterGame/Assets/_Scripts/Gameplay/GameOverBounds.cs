using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverBounds : MonoBehaviour
{
    int health = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Debug.Log("Destroyed");
            Destroy(gameObject);
        }
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
            health--;
            Debug.Log("Triggered by Bullet. Current Health = " + health);
        }
    }
}
