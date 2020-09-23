using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    Material material;
    Vector2 offset;

    public float xVelocity;
    public float yVelocity;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Assigning offset variable
        offset = new Vector2(xVelocity, yVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        // Updating material offset
        material.mainTextureOffset += offset * Time.deltaTime;
    }
}
