using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelSelector : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip levelSelectorMusic;
    public Button[] levelButtons;
    public Image[] lockers;

    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("LevelReached", 1);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
                lockers[i].gameObject.SetActive(true);
            }
        }
        audioSource.clip = levelSelectorMusic;
        audioSource.Play();
    }

    void Update()
    {
        if(!audioSource.isPlaying)
        {
            audioSource.Play();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayerPrefs.SetInt("LevelReached", 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void LoadLevelPassed(string levelName)
    {
        PlayerPrefs.SetInt("LevelLoadedByLevelSelelector", 1);
        // Load the level passed as a parameter
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
    }
}
