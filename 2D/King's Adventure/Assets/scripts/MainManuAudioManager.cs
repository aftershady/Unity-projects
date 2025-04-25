using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System.Collections;

public class MainManuAudioManager : MonoBehaviour
{
    public AudioMixerGroup SoundEffectsMixer;
    public AudioClip[] playlist;
    public AudioSource audioSource;
    // Start is called before the first frame update
    public static MainManuAudioManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("there is more than one instance MainManuAudioManager");
        }
        instance = this;
    }
    void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();
    }

        void Update()
    {
        if(!audioSource.isPlaying)
        {
            //if player is alive and audio is not playing
            audioSource.Play();
        }
    }



}
