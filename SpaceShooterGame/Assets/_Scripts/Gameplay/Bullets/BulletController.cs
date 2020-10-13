using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class BulletController : MonoBehaviour
{
    public bool isGoingUp = false;
    public float verticalSpeed;
    public float verticalBounds;
    public BulletManager bulletManager;

    // Start is called before the first frame update
    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    private void Move()
    {
        if (isGoingUp == true) // Projectile is firing upwards
        {
            transform.position += new Vector3(0.0f, verticalSpeed, 0.0f) * Time.deltaTime;
        }
        else if (isGoingUp == false) // Projectile is firing downwards
        {
            transform.position += new Vector3(0.0f, -verticalSpeed, 0.0f) * Time.deltaTime;
        }
    }

    private void CheckBounds()
    {
        if (transform.position.y > verticalBounds || transform.position.y < -verticalBounds)
        {
            bulletManager.ReturnBullet(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && isGoingUp == true)
        {
            SoundManager.PlaySound("impact");
            bulletManager.ReturnBullet(gameObject);
        }
        else if (collision.tag == "Player" && isGoingUp == false)
        {
            bulletManager.ReturnBullet(gameObject);
        }
    }
}
