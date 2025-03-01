using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    public string levelToLoad;
    public GameObject SettingsWindow;

    public void start()
    {
        Screen.fullScreen = true;
    }

    public void StartGame()
    {
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
