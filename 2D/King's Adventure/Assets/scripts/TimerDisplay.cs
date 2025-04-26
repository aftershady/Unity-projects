using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class TimerDisplay : MonoBehaviour
{
    public GameObject timerObject;
    public Text timerText;
    public int minutes = 0;
    public int seconds = 0;

    private float elapsedTime = 0f;

    public static TimerDisplay instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("there is more than one instance TimerDisplay");
        }

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(timerObject);
        }
        else
        {
            Destroy(timerObject); // détruire le doublon
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            ResetTimer();
        }
        else
        {
            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            // Calculate minutes and seconds
            minutes = Mathf.FloorToInt(elapsedTime / 60F);
            seconds = Mathf.FloorToInt(elapsedTime % 60F);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void ResetTimer()
    {
        elapsedTime = 0f;
        timerText.text = "00:00";
        enabled = true;
    }

    public void Continue()
    {
        enabled = true;

    }

    public void PauseTimer()
    {
        // Do nothing to Time.timeScale, only stop updating the timer
        enabled = false;
    }
}
