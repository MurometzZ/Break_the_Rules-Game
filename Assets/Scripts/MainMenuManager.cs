using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] Canvas mainCanvas;
    [SerializeField] Canvas levelsCanvas;
    [SerializeField] Canvas settingsCanvas;

    void Start()
    {
        BackToMainMenu();
    }

    void Update()
    {
        
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenLevelSelector()
    {
        levelsCanvas.gameObject.SetActive(true);
        mainCanvas.gameObject.SetActive(false);
    }

    public void OpenSettings()
    {
        settingsCanvas.gameObject.SetActive(true);
        mainCanvas.gameObject.SetActive(false);
    }

    public void BackToMainMenu()
    {
        mainCanvas.gameObject.SetActive(true);
        levelsCanvas.gameObject.SetActive(false);
        settingsCanvas.gameObject.SetActive(false);
    }
}