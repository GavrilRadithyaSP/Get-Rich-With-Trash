using UnityEngine;
using Terresquall;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.x = VirtualJoystick.GetAxisRaw("Horizontal");
        movement.y = VirtualJoystick.GetAxisRaw("Vertical");

        movement = movement.normalized;

        bool isMoving = movement.magnitude > 0.01f;
        animator.SetBool("Running", isMoving);

        if (movement.x < 0)
            spriteRenderer.flipX = false;
        else if (movement.x > 0)
            spriteRenderer.flipX = true;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
