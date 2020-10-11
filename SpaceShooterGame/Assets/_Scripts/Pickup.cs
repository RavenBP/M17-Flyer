using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Pickup : MonoBehaviour
{
    public SpriteRenderer pickupSprite;
    public Sprite scoreSprite;
    public Sprite livesSprite;

    int pickupType;
    bool increaseLives;
    bool increaseScore;
    float verticalSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        increaseLives = false;
        increaseScore = false;

        pickupType = Random.Range(1, 10);

        Debug.Log("Pickup type = " + pickupType);

        if (pickupType >= 9) // Spawn extra life pickup
        {
            increaseLives = true;
            pickupSprite.sprite = livesSprite;
        }
        else // Spawn extra score pickup
        {
            increaseScore = true;
            pickupSprite.sprite = scoreSprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckPosition();
    }

    void Move()
    {
        Vector3 newPosition;
        newPosition = new Vector3(0.0f, -verticalSpeed, 0.0f) * Time.deltaTime;
        transform.Translate(newPosition);
    }

    void CheckPosition()
    {
        if (transform.position.y <= -4.0f) // If pickup reaches bottom of screen
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (increaseLives == true)
            {
                PlayerController.playerLives++;
            }
            else if (increaseScore == true)
            {
                Score.scoreValue += 75;
            }

            Destroy(gameObject);
            Debug.Log("Picked up pickup");
        }
    }
}
