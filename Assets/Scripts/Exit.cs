using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.loadedSceneCount + 1);
        }
    }
}
