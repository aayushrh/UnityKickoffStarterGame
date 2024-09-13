using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float FRICTION = 0.9f;
    [SerializeField] float SPEED = 20f;
    Vector2 velocity = Vector2.zero;
    Rigidbody2D rb = null;
    public GameObject caught = null;
    public float progress = 0.5f;
    private Boolean dashing = false;
    private int dashTimer = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<BoxCollider2D>().isTrigger = false;
        if (caught != null)
        {
            rb.velocity = Vector2.zero;
            GetComponent<BoxCollider2D>().isTrigger = true;
            progress -= 0.0005f;
            Debug.Log(progress);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                progress += 0.1f;
            }

            if (progress > 1)
            {
                caught = null;
            }

            if (progress < 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            if (caught.transform.position.y > 5)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            gameObject.transform.position = caught.transform.position;
        }
        else if (dashing)
        {
            dashTimer -= 1;
            if(dashTimer < 0)
            {
                dashing = false;
            }
        }
        else
        {
            Move();
        }


        Vector2 newPos = rb.velocity/60 + new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        if (newPos.y > 5 || newPos.y < -5 || newPos.x > 8.5 || newPos.x < -8.5)
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 inputV = Vector2.zero;

        inputV.x += moveX * SPEED;
        inputV.y += moveY * SPEED;

        inputV.Normalize();
        velocity += inputV * SPEED;

        velocity *= FRICTION;

        if (Math.Abs(velocity.x) < 0.01)
        {
            velocity.x = 0;
        }
        if (Math.Abs(velocity.y) < 0.01)
        {
            velocity.y = 0;
        }

        rb.velocity = velocity;

        rb.SetRotation((float)(Math.Atan2(velocity.y, velocity.x) * 180 / Math.PI));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("dashin");
            dashing = true;
            dashTimer = 10;
            Vector2 prevV = velocity;
            velocity.Normalize();
            rb.velocity = velocity * 100;
            velocity = prevV;
        }
    }
}
