using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject SettingsWindow;

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

    public void CloseSettingsButton()
    {
        SettingsWindow.SetActive(false);
    }

	public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
