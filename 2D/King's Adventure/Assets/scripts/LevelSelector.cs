using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelSelector : MonoBehaviour
{
    public Button[] levelButtons;
    public Image[] lockers;
    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("LevelReached", 1);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
                lockers[i].gameObject.SetActive(true);
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Save is deleted");
            PlayerPrefs.SetInt("LevelReached", 1);
        }
    }

    public void LoadLevelPassed(string levelName)
    {
        // Load the level passed as a parameter
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
    }
}
