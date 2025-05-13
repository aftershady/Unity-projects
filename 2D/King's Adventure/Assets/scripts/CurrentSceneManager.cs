using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    public bool isPlayerPresentByDefault = false;
    public bool isPlayerHaveTakenTheCheckpoint = false;
    public int levelToUnlock;
    public static CurrentSceneManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("there is more than one instance CurrentSceneManager");
        }
        instance = this;
    }
}
