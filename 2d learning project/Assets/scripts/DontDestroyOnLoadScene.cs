using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject timer;
    public static DontDestroyOnLoadScene instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("there is more than one instance DontDestroyOnLoadScene");
        }
        instance = this;

        AddToDontDestroyOnLoad(objects);

        if (timer != null)
        {
            DontDestroyOnLoad(timer);
        }
    }

    public void RemoveFromDontDestroyOnLoad()
    {
        foreach(var element in objects)
        {
            SceneManager.MoveGameObjectToScene(element, SceneManager.GetActiveScene());
        }
    }

    public void AddToDontDestroyOnLoad(GameObject[] objects)
    {
        Debug.Log("Adding objects to DontDestroyOnLoad");
        foreach(var element in objects)
        {
            DontDestroyOnLoad(element);
        }
    }
}
