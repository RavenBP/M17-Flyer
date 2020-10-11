using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5.0f;
    private bool touchStart = false;
    public static int playerLives = 3;
    private Vector2 initialTouchPos;
    private Vector2 currentTouchPos;

    public BulletManager bulletManager;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            initialTouchPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }

        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            currentTouchPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
            touchStart = false;
        }

        FireBullet();
    }

    private void FireBullet()
    {
        if (Time.frameCount % 60 == 0)
        {
            bulletManager.GetBullet(transform.position);
        }
    }

    private void FixedUpdate()
    {
        if (touchStart)
        {
            Vector2 offset = currentTouchPos - initialTouchPos;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            moveCharacter(direction);
        }

    }

    int GetPlayerLives()
    {
        return playerLives;
    }

    void SetPlayerLives(int lives)
    {
        playerLives = lives;
    }

    void moveCharacter(Vector2 direction)
    {
        rb.transform.Translate(direction * speed * Time.deltaTime);
    }
}
