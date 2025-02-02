using UnityEngine;

public class TripleJump : MonoBehaviour
{
    public bool isActive = false;
    [SerializeField] GameObject icon;

    public int normalJumps = 1;  // Default jump count
    public int tripleJumps = 3;  // Triple jump count
    private int maxJumps;
    private int jumpsLeft;
    private bool usedAirJump = false; // Track if air jump was used

    PlayerMovement playerMovement;
    PlayerCheats playerCheats;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerCheats = GetComponent<PlayerCheats>();
        maxJumps = normalJumps;
        jumpsLeft = maxJumps;
    }

    void Update()
    {
        if (!isActive) return;

        if (Input.GetButtonDown("Jump"))
        {
            if (playerMovement.isGrounded || jumpsLeft > 0)
            {
                playerMovement.Jump();
                if (!playerMovement.isGrounded)
                {
                    jumpsLeft--;
                    usedAirJump = true; // Mark that an air jump was used
                }
            }
            else if (jumpsLeft <= 0)
            {
                Deactivate();
            }
        }
    }

    public void Activate()
    {
        maxJumps = tripleJumps;
        jumpsLeft = maxJumps;
        usedAirJump = false; // Reset when activated

        icon.SetActive(true);
        isActive = true;
        playerCheats.isUsingCheats = true;
    }

    public void Deactivate()
    {
        maxJumps = normalJumps;
        jumpsLeft = maxJumps;

        icon.SetActive(false);
        isActive = false;
        playerCheats.isUsingCheats = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (playerMovement.isGrounded)
        {
            jumpsLeft = maxJumps;
            if (usedAirJump)
            {
                Deactivate(); // Deactivate if an air jump was made before landing
            }
        }
    }
}
