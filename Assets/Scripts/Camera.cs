using System.Collections;
using UnityEngine;

public class Camera : MonoBehaviour
{
    bool playerCaught = false;

    public Transform turnAxis;
    public float minTurnAngle = -30f;
    public float maxTurnAngle = 30f;
    //public float turnRadius = 30f;
    public float rotationSpeed = 20f;
    public float pauseDuration = 1f;
    public float detectionRange = 10f;
    public float detectionAngle = 45f;
    public int rayCount = 10;
    public LayerMask obstacleMask;
    public LayerMask playerMask;
    public Vector2 rayDirection = Vector2.right; // Base direction (relative to turnAxis)

    private bool rotatingRight = true;
    private bool isPaused = false;

    public Canvas playerCaughtCanvas;
    public PlayerCheats playerCheats;
    public PlayerMovement playerMovement;

    void Start()
    {
        playerCaughtCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        DetectPlayer();
        if (isPaused) return;

        float angle = Mathf.DeltaAngle(0, turnAxis.eulerAngles.z);
        if (rotatingRight && angle >= maxTurnAngle) StartCoroutine(PauseBeforeSwitch(false));
        else if (!rotatingRight && angle <= minTurnAngle) StartCoroutine(PauseBeforeSwitch(true));

        float direction = rotatingRight ? 1 : -1;
        turnAxis.Rotate(0, 0, direction * rotationSpeed * Time.deltaTime);
    }

    IEnumerator PauseBeforeSwitch(bool newDirection)
    {
        isPaused = true;
        yield return new WaitForSeconds(pauseDuration);
        rotatingRight = newDirection;
        isPaused = false;
    }

    void DetectPlayer()
    {
        if(playerCaught) return;

        Vector2 baseDirection = turnAxis.TransformDirection(rayDirection).normalized; // Rotate ray direction with turnAxis

        for (int i = 0; i < rayCount; i++)
        {
            float spread = Mathf.Lerp(-detectionAngle / 2, detectionAngle / 2, (float)i / (rayCount - 1));
            Vector2 direction = (Quaternion.Euler(0, 0, spread) * baseDirection).normalized; // Apply spread relative to rotated base direction

            RaycastHit2D hit = Physics2D.Raycast(turnAxis.position, direction, detectionRange, obstacleMask | playerMask);

            if (hit.collider != null)
            {
                if (((1 << hit.collider.gameObject.layer) & playerMask) != 0)
                {
                    if(playerCheats.isUsingCheats)
                        PlayerCaught();
                }
            }

            Debug.DrawRay(turnAxis.position, direction * (hit.collider ? hit.distance : detectionRange), hit.collider ? Color.red : Color.green);
        }
    }

    void PlayerCaught()
    {
        playerCaught = true;

        playerMovement.canMove = false;
        playerCaughtCanvas.gameObject.SetActive(true);
    }
}
