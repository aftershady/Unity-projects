using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{
    public string sceneName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the player tag enter in coin
        if(collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
