using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    public bool isPlayerPresentByDefault = false;
    public bool isPlayerHaveTakenTheCheckpoint = false;
    public int levelToUnlock;
    public bool isLoadedByLevelSelector = false;
    public static CurrentSceneManager instance;

    private void Awake()
    {
        isLoadedByLevelSelector = PlayerPrefs.GetInt("isLoadedByLevelSelector", 0) == 1;
        if (isLoadedByLevelSelector && UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "Level 01")
        {
            Debug.Log("Loaded by Level Selector");
            TimerDisplay.instance.minutes += 1;
            PlayerPrefs.SetInt("isLoadedByLevelSelector", 0);
        }
        if (instance != null)
        {
            Debug.LogWarning("there is more than one instance CurrentSceneManager");
        }
        instance = this;
    }
}
