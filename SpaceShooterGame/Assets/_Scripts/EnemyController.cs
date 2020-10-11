using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public SpriteRenderer enemySprite;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;

    float verticalSpeed = 5.0f;

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
        if (transform.position.y <= -4.0f)
        {
            transform.position = new Vector3(Random.Range(-2.5f, 2.5f), 5.0f, 0.0f);
        }    
    }
}
