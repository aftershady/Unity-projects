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

        AddToDontDestroyOnLoad(objects);

    }

    public void RemoveFromDontDestroyOnLoad()
    {
        foreach(var element in objects)
        {
            SceneManager.MoveGameObjectToScene(element, SceneManager.GetActiveScene());
        }
        SceneManager.MoveGameObjectToScene(Timer, SceneManager.GetActiveScene());
    }

    public void AddToDontDestroyOnLoad(GameObject[] objects)
    {

        foreach(var element in objects)
        {
            DontDestroyOnLoad(element);
        }
    }
}
