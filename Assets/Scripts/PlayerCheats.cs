using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements.Experimental;

public class PlayerCheats : MonoBehaviour
{
    public bool isUsingCheats = false;

    [Header("References")]
    PlayerMovement playerMovement;
    SuperSpeed superSpeed;
    TripleJump tripleJump;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        superSpeed = GetComponent<SuperSpeed>();
        tripleJump = GetComponent<TripleJump>();
    }

    void Update()
    {
        if (isUsingCheats) return;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Cheat 1 activated (Super Speed)");

            superSpeed.Activate();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && SceneManager.GetActiveScene().buildIndex >= 3)
        {
            Debug.Log("Cheat 2 activated (Triple Jump)");

            tripleJump.Activate();
        }
    }
}
