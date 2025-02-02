using UnityEngine;

public class SuperSpeed : MonoBehaviour
{
    public bool isActive = false;
    public float effectLength = 5f;

    public float speedIncrease = 2.5f;
    public float jumpForceIncrease = 2.5f;

    [Header("References")]
    PlayerMovement playerMovement;
    PlayerCheats playerCheats;
    [SerializeField] GameObject icon;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerCheats = GetComponent<PlayerCheats>();
    }

    public void Activate()
    {
        playerMovement.movementSpeed *= speedIncrease;
        playerMovement.jumpForce *= jumpForceIncrease;

        playerCheats.isUsingCheats = true;

        icon.SetActive(true);

        Deactivate();
    }

    void Deactivate()
    {
        Invoke("DisableEffects", effectLength);
    }

    void DisableEffects()
    {
        playerMovement.movementSpeed /= speedIncrease;
        playerMovement.jumpForce /= jumpForceIncrease;

        playerCheats.isUsingCheats = false;
        icon.SetActive(false);
    }
}
