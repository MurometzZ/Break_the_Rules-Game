using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class PlayerCheats : MonoBehaviour
{
    public bool isUsingCheats = false;

    [Header("References")]
    PlayerMovement playerMovement;
    SuperSpeed superSpeed;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        superSpeed = GetComponent<SuperSpeed>();
    }

    void Update()
    {
        if (isUsingCheats) return;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Cheat 1 activated (Super Speed)");

            superSpeed.Activate();
        }
    }
}
