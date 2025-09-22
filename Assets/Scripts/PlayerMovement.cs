using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;

    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;

    private void Awake()
    {
        // Rigidbody2D and Collider are on PlayerRoot
        body = GetComponent<Rigidbody2D>();

        // Animator is inside CharacterVisual (child)
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Move player
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        // Flip CharacterVisual (not the root) based on direction
        if (horizontalInput > 0.01f)
        {
            anim.transform.localScale = new Vector3(-1, 1, 1); 
        }
        else if (horizontalInput < -0.01f)
        {
            anim.transform.localScale = new Vector3(1, 1, 1); 
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
        }

        // Update Animator parameters
        anim.SetBool("Running", horizontalInput != 0);
        anim.SetBool("OnGround", grounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpPower);
        anim.SetTrigger("Jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}
