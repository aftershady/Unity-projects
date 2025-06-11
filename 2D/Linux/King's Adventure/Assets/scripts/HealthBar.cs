using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //add the slider of the fill of the health bar
    public Slider slider;
    //gradient for fill color
    public Gradient gradient;
    //add fill liked to the slider
    public Image fill;

    public void SetMaxHealth(int health)
    {
        //set the slider value from the playerhealth script and store it in the max value and actual value
        slider.maxValue = health;
        slider.value = health;
        //change the color of the fill to the 1 value to the gradient (right of the gradient)
        //if 0.5f, it will be to the middle
        fill.color = gradient.Evaluate(1F);
    }

    public void SetHealth(int health)
    {
        //update the actual value
        slider.value = health;
        //update the color, in the gradient she will be match with the position of the gradient 50% = 0.5 of the gradient
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
