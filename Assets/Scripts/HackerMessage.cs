using TMPro;
using UnityEngine;

public class HackerMessage : MonoBehaviour
{
    public Canvas messageCanvas;
    public TMP_Text messageText;

    void Start()
    {
        messageCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CloseMessage();
        }
    }

    public void ShowMessage(string message)
    {
        messageCanvas.gameObject.SetActive(true);

        messageText.text = message;
    }

    public void CloseMessage()
    {
        messageCanvas.gameObject.SetActive(false);
    }
}
