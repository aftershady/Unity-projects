using UnityEngine;

public class ItemsDatabase : MonoBehaviour
{
    public Item[] allItems;
    public static ItemsDatabase instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("there is more than one instance ItemsDatabase");
        }
        instance = this;
    }
}
