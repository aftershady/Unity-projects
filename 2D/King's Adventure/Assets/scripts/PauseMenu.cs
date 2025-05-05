using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class PauseMenu : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip openMenuSound;
    public AudioClip closeMenuSound;
    public GameObject SettingsWindow;
    public bool soundisPlaying = false;

    public void Paused()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void SettingsButton()
    {
        SettingsWindow.SetActive(true);
    }

    public void OpenMenuSound()
    {
        audioSource.PlayOneShot(openMenuSound);
    }

    public void CloseMenuSound()
    {
        AudioManager.instance.PlayClipAt(closeMenuSound, transform.position);
    }

    public void CloseSettingsButton()
    {
        SettingsWindow.SetActive(false);
    }

	public void ReturnToMainMenu()
    {
        DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

        public void levelSliderSound()
    {
        if (!soundisPlaying)
        {
            soundisPlaying = true;
            StartCoroutine(PlaylevelSliderSound());
        }
    }

    public IEnumerator PlaylevelSliderSound()
    {
        audioSource.PlayOneShot(openMenuSound);
        yield return new WaitForSeconds(1f);
        soundisPlaying = false;
    }

}
