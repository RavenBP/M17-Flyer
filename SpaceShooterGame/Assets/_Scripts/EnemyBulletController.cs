using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class EnemyBulletController : MonoBehaviour
{
    public float verticalSpeed;
    public float verticalBounds;
    public EnemyBulletManager bulletManager;

    // Start is called before the first frame update
    void Start()
    {
        bulletManager = FindObjectOfType<EnemyBulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    private void Move()
    {
        transform.position += new Vector3(0.0f, -verticalSpeed, 0.0f) * Time.deltaTime;
    }

    private void CheckBounds()
    {
        if (transform.position.y < verticalBounds)
        {
            bulletManager.ReturnBullet(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            bulletManager.ReturnBullet(gameObject);
        }
    }
}