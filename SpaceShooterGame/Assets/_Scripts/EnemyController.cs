using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public SpriteRenderer enemySprite;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;

    public GameObject pickupGO;

    float verticalSpeed = 1.0f;
    int health = 5;
    int pickupDropChance;

    // Start is called before the first frame update
    void Start()
    {
        // Assign random sprite to each enemy
        int num = Random.Range(1, 5);
        Debug.Log("Random number chosen = " + num);

        switch (num)
        {
            case 1:
                enemySprite.sprite = sprite1;
                break;
            case 2:
                enemySprite.sprite = sprite2;
                break;
            case 3:
                enemySprite.sprite = sprite3;
                break;
            case 4:
                enemySprite.sprite = sprite4;
                break;
            case 5:
                enemySprite.sprite = sprite5;
                break;
        }

        // Assign random drop chance for enemy
        pickupDropChance = Random.Range(1, 10);
        Debug.Log("Pickup drop chance = " + pickupDropChance);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckPosition();

        if (health <= 0)
        {
            Score.scoreValue += 75;

            if (pickupDropChance >= 8)
            {
                Instantiate(pickupGO, new Vector3(Random.Range(-2.5f, 2.5f), 5.0f, 0.0f), Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            }

            Respawn();
        }
    }

    void Move()
    {
        Vector3 newPosition;
        newPosition = new Vector3(0.0f, -verticalSpeed, 0.0f) * Time.deltaTime;
        transform.Translate(newPosition);
    }

    void CheckPosition()
    {
        if (transform.position.y <= -4.0f) // If player reaches the bottom of the screen
        {
            Respawn();
        }    
    }

    void Respawn()
    {
        transform.position = new Vector3(Random.Range(-2.5f, 2.5f), 5.0f, 0.0f); // Set enemy's position in random area at top of screen
        health = 5;
        
        // Change pickup drop chance
        pickupDropChance = Random.Range(1, 10);
        Debug.Log("NEW Pickup drop chance = " + pickupDropChance);
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
        else if (collision.tag == "Bullet") // Enemy is hit by bullet
        {
            health--;
            //Debug.Log("Triggered by Bullet. Current Health = " + health);
        }
    }
}
