using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour
{
    public Text timerText;

    void Update()
    {
        
        // Get the current time in seconds
            timerText.text = string.Format("{0:00}:{1:00}", 10, 20);
    }
}
