using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingLineBehaviour : MonoBehaviour
{
    [SerializeField] Vector2 velocity = new Vector2(20, -20);
    [SerializeField] Vector2 acceleration = new Vector2(-1, 1);
    Rigidbody2D rb = null;
    public Boolean right = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (!right)
        {
            velocity.x *= -1;
            acceleration.x *= -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        velocity += acceleration;
        rb.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().caught = gameObject;
            collision.gameObject.GetComponent<PlayerMovement>().progress = 0.5f;
        }
    }
}
