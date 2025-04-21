using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public bool victorySoundIsPlayed = false;
    public bool coroutineStarted = false;
    public bool bossIsDead = false;

    //audio
    public AudioMixerGroup SoundEffectsMixer;
    public AudioClip[] playlist;
    public AudioSource audioSource;

    //singleton
    public static AudioManager instance;

    public AudioClip openBossDoorSound;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("there is more than one instance AudioManager");
        }
        instance = this;
    }
    void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

        if(PlayerHealth.instance.currentHealth > 0 && !audioSource.isPlaying)
        {
            //if player is alive and audio is not playing
            audioSource.Play();
        }
        if (SceneManager.GetActiveScene().name == "Level 03" && !bossIsDead)
        {
            //play boss music
            audioSource.clip = playlist[1];
        }
        if (SceneManager.GetActiveScene().name == "Level 03" && bossIsDead && coroutineStarted == false)
        {
            //boss is dead
            coroutineStarted = true;
            StartCoroutine(PlayVictorySound());
        }
    }

    private IEnumerator PlayVictorySound()
    {
        if(!victorySoundIsPlayed)
        {
            victorySoundIsPlayed = true;
            audioSource.clip = playlist[2];
            yield return new WaitForSeconds(playlist[2].length);
            audioSource.PlayOneShot(openBossDoorSound);
        }
        audioSource.clip = playlist[3];
    }

    public AudioSource PlayClipAt(AudioClip clip, Vector3 pos)
    {
        GameObject tempGO = new GameObject("TempAudio");
        tempGO.transform.position = pos;
        AudioSource audioSource = tempGO.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.outputAudioMixerGroup = SoundEffectsMixer;
        audioSource.Play();
        Destroy(tempGO, clip.length);
        return audioSource;
    }


}
