using UnityEngine;

public class MoveableBox : MonoBehaviour
{
    [SerializeField] SuperStrength superStrength;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (superStrength != null)
        {
            if (superStrength.isActive)
            {
                rb.mass = 2;
            }
            else
            {
                rb.mass = 9999;
            }
        }
    }
}
