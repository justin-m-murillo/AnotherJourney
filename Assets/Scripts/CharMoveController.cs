using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharMoveController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float speed;
    public float jumpingPower;
    public bool isMoving = false;
    public float y_diff;

    private float horizontal;
    private float horzSpeed = 0f;
    private bool isFacingRight = true;
    private float previousY;

    // Start is called before the first frame update
    void Start()
    {
        horizontal = 0f;
        previousY = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horzSpeed = IsGrounded() ? horizontal * speed : horzSpeed;
        rb.velocity = new Vector2(horzSpeed, rb.velocity.y);
        isMoving = horizontal != 0f;

        y_diff = transform.position.y - previousY;
        previousY = transform.position.y;

        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }

    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    public void Jump(bool fullJump)
    {
        if (fullJump && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (!fullJump && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }
    
    public void Move(float input)
    {
        horizontal = input;
    }
}
