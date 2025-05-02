using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void LoadLevelPassed(string levelName)
    {
        // Load the level passed as a parameter
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
    }
}
