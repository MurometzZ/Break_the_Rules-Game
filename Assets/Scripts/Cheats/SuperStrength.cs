using UnityEngine;

public class SuperStrength : MonoBehaviour
{
    public bool isActive = false;
    public float effectLength = 5f;

    [SerializeField] PlayerCheats playerCheats;
    [SerializeField] GameObject icon;

    public void Activate()
    {
        isActive = true;
        playerCheats.isUsingCheats = true;
        icon.SetActive(true);
        Deactivate(effectLength);
    }

    public void Deactivate(float delay)
    {
        Invoke("DisableEffects", delay);
    }

    void DisableEffects()
    {
        isActive = false;
        playerCheats.isUsingCheats = false;
        icon.SetActive(false);
    }
}
