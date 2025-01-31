using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool isGrounded;

    [Header("Player Stats")]
    public float movementSpeed = 10f;
    public float jumpForce = 5f;

    [Header("Script & Component References")]
    public Transform groundCheck;
    public LayerMask groundLayer;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        if (Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer))
            isGrounded = true;
        else 
            isGrounded = false;

        float moveInput = Input.GetAxis("Horizontal");

        if (Input.GetButton("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        rb.linearVelocity = new Vector2(moveInput * movementSpeed, rb.linearVelocity.y);
    }
}
