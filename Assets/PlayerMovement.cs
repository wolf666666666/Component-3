using System.Collections;
using System.Net;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;

    public float sprintMultiplier = 1.1f;

    public Rigidbody2D rb;
    public float jumpForce = 5f;
    public bool isGrounded;

    public Transform rSpawn;
    
    void Start()
    {
        
    }

    void Update()
    {
        Jump();

        Movement();

        Fall();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }

    void Movement()
    {
        Vector2 direction = new Vector2(1, 0) * Input.GetAxisRaw("Horizontal");
        transform.Translate(direction * speed * Time.deltaTime);

        if (direction.x != 0 && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(direction * (speed * sprintMultiplier) * Time.deltaTime);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
        }
    }
    
    void Fall()
    {
        if (transform.position.y < -15)
        {
            transform.position = rSpawn.transform.position;
        }
    }
}
