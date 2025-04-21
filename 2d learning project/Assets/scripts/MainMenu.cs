using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip openMenuSound;
    public AudioClip closeMenuSound;
    public string levelToLoad;
    public GameObject SettingsWindow;
    public void start()
    {
        Screen.fullScreen = true;
    }

    public void OpenMenuSound()
    {
        audioSource.PlayOneShot(openMenuSound);
    }

    public void CloseMenuSound()
    {
        audioSource.PlayOneShot(closeMenuSound);
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(levelToLoad);
    }


    public void SettingsButton()
    {
        SettingsWindow.SetActive(true);
    }

        public void CloseSettingsButton()
    {
        SettingsWindow.SetActive(false);
    }

        public void QuitGame()
    {
        Application.Quit();
    }
}
