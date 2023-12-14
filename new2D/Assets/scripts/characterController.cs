using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 350f;

    private Rigidbody2D rb;
    private bool grounded;
    private bool started;
    private Animator _animator;
    private bool jumping;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        grounded = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (started && grounded)
            {
                _animator.SetTrigger("jump");
                grounded = false;
                jumping = true;
            }
            else
            {
                _animator.SetBool("gameStarted", true);
                started = true;
            }
        }

        _animator.SetBool("grounded", grounded);
    }


    private void FixedUpdate()
    {
        if (started)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }

        if(jumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            jumping = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("ground"))
        {
            grounded = true;
        }
    }
}
