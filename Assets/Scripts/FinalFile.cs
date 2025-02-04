using UnityEngine;

public class FinalFile : MonoBehaviour
{
    public Canvas winCanvas;

    void Start()
    {
        winCanvas.gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            winCanvas.gameObject.SetActive(true);
        }
    }
}
