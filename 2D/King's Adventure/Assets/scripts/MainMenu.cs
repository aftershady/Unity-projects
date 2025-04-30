using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class MainMenu : MonoBehaviour
{
    public GameObject Creditscanvas;
    public GameObject creditsContent;
    public AudioSource audioSource;
    public AudioClip openMenuSound;
    public AudioClip closeMenuSound;

    public string levelToLoad;

    private Coroutine creditsCoroutine;

    public GameObject escapeButton;
    public bool isEscapeButtonActive = false;
    public GameObject SettingsWindow;
    public bool soundisPlaying = false;

    public bool creditsArePlaying = false;

    public void start()
    {
        Screen.fullScreen = true;
    }

    void Update()
    {
        if (creditsArePlaying)
        {
            if (Input.anyKeyDown)
            {
                if(!isEscapeButtonActive)
                {
                    StartCoroutine(ActivateEscapeButton());
                }
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    StopCoroutine(creditsCoroutine);
                    creditsCoroutine = null;
                    Creditscanvas.SetActive(false);
                    creditsContent.GetComponent<Animator>().SetTrigger("StopCredits");
                }
            }
        }
    }

    public void OpenMenuSound()
    {
        audioSource.PlayOneShot(openMenuSound);
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

    public void CloseMenuSound()
    {
        audioSource.PlayOneShot(closeMenuSound);
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(levelToLoad);
    }

    public void LevelSelect()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level Select Menu");
    }

    public void PlayCredits()
    {
        Creditscanvas.SetActive(true);
        creditsCoroutine = StartCoroutine(waitForCredits());
        creditsContent.GetComponent<Animator>().SetTrigger("StartCredits");
        creditsArePlaying = true;
    }

    public IEnumerator waitForCredits()
    {
        yield return new WaitForSeconds(85);
        creditsCoroutine = null;
        Creditscanvas.SetActive(false);
        creditsContent.GetComponent<Animator>().SetTrigger("StopCredits");
        creditsArePlaying = false;
    }

    public IEnumerator ActivateEscapeButton()
    {
            isEscapeButtonActive = true;
            escapeButton.SetActive(true);
            yield return new WaitForSeconds(8f);
            escapeButton.SetActive(false);
            isEscapeButtonActive = false;
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
