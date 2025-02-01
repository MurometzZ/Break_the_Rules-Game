using UnityEngine;

public class Message : MonoBehaviour
{
    public string message;
    public float delay;

    public bool used = false;

    [SerializeField] HackerMessage hackerMessage;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Collision detected with message");

        if (used) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            if (delay > 0)
            {
                Invoke("OpenMessage", delay);
            }
            else
            {
                OpenMessage();
            }
        }
    }

    void OpenMessage()
    {
        hackerMessage.ShowMessage(message);
        
        used = true;
    }
}