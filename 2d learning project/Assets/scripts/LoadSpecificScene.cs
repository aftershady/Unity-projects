using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the player tag enter in coin
        if(collision.CompareTag("Player"))
        {
            SceneManager.LoadScene("Level 02");
        }
    }
}
