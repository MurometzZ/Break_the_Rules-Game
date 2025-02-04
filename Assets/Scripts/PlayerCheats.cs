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
    SuperStrength superStrength;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        superSpeed = GetComponent<SuperSpeed>();
        tripleJump = GetComponent<TripleJump>();
        superStrength = GetComponent<SuperStrength>();
    }

    void Update()
    {
        if (superSpeed.isActive && Input.GetKeyDown(KeyCode.Alpha1))
        {
            superSpeed.DisableEffects();
            return;
        }

        if (tripleJump.isActive && Input.GetKeyDown(KeyCode.Alpha2))
        {
            tripleJump.Deactivate();
        }

        if (superStrength.isActive && Input.GetKeyDown(KeyCode.Alpha3))
        {
            superStrength.Deactivate(0.01f);
        }

        if (isUsingCheats) return;

        if (Input.GetKeyDown(KeyCode.Alpha1) && !superStrength.isActive)
        {
            superSpeed.Activate();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && SceneManager.GetActiveScene().buildIndex >= 3 && !superSpeed.isActive && !superStrength.isActive)
        {
            tripleJump.Activate();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && SceneManager.GetActiveScene().buildIndex >= 5 && !superSpeed.isActive)
        {
            superStrength.Activate();
        }
    }
}
