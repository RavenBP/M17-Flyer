using System.Collections;
using System.Collections.Generic;
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
            PlayerController.playerLives -= 1;

            if (PlayerController.playerLives <= -1)
            {
                SceneManager.LoadScene("GameOverScene");
            }
        }
    }
}
