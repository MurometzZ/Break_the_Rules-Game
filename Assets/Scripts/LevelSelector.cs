using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Button[] levelButtons;

    void Start()
    {
        if (!PlayerPrefs.HasKey("LevelsUnlocked"))
        {
            PlayerPrefs.SetInt("LevelsUnlocked", 1); // If there is no save, set the levels unlocked to 1
        }

        int levelsUnlocked = PlayerPrefs.GetInt("LevelsUnlocked");

        foreach (Button b in levelButtons)
        {
            b.interactable = false;
        }

        for (int i = 0; i < levelsUnlocked; i++)
        {
            levelButtons[i].interactable = true;
        }
    }

    void Update()
    {
        
    }

    public void OpenLevel(int levelNum)
    {
        SceneManager.LoadScene(levelNum);
    }
}
