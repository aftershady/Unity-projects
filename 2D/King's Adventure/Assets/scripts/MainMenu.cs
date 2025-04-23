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
    public GameObject SettingsWindow;

    public bool creditsArePlaying = false;

                //LINK STOP CREDITS ANIMATION
                //RESOLVE PROBLEM WITH AUDIO OF MAIN MENU
                //ESC TOUCH TO ADD
                //EDIT CURVE TO END CREDITS
                // CORRECT TITLE OF GAME IN CREDITS

    public void start()
    {
        Screen.fullScreen = true;
    }

    void Update()
    {
        if (creditsArePlaying)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Creditscanvas.SetActive(false);
                creditsContent.GetComponent<Animator>().SetTrigger("StopCredits");
            }
        }
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

    public void PlayCredits()
    {
        Creditscanvas.SetActive(true);
        StartCoroutine(waitForCredits());
        creditsContent.GetComponent<Animator>().SetTrigger("StartCredits");
        creditsArePlaying = true;
    }

    public IEnumerator waitForCredits()
    {
        yield return new WaitForSeconds(60);
        SceneManager.LoadScene("Main Menu");
        creditsArePlaying = false;
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
