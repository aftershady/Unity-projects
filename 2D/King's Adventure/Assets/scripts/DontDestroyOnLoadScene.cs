using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject Timer;
    public static DontDestroyOnLoadScene instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("there is more than one instance DontDestroyOnLoadScene");
        }
        instance = this;

    }

    public void RemoveFromDontDestroyOnLoad()
    {
        foreach(var element in objects)
        {
            SceneManager.MoveGameObjectToScene(element, SceneManager.GetActiveScene());
        }
        SceneManager.MoveGameObjectToScene(Timer, SceneManager.GetActiveScene());
    }
}
