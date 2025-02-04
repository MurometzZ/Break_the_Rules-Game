using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gamePaused = false;

    [SerializeField] Canvas pausedCanvas; 

    void Start()
    {
        ResumeGame();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(gamePaused) ResumeGame();
            else PauseGame();
        }
    }

    public void PauseGame()
    {
        gamePaused = true;

        Time.timeScale = 0;
        pausedCanvas.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        gamePaused = false;

        Time.timeScale = 1;
        pausedCanvas.gameObject.SetActive(false);
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
