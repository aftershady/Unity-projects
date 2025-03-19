using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    public AudioClip[] playlist;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        if (SceneManager.GetActiveScene().name == "Level 03")
        {
            audioSource.clip = playlist[1];
        }
    }


}
