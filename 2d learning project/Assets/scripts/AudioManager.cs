using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixerGroup SoundEffectsMixer;
    public AudioClip[] playlist;
    public AudioSource audioSource;
    // Start is called before the first frame update
    public static AudioManager instance;

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
        if(!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        if (SceneManager.GetActiveScene().name == "Level 03")
        {
            audioSource.clip = playlist[1];
        }
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
