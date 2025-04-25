using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    Resolution[] resolutions;
    public Dropdown resolutionDropdown;
    public Slider musicSlider;
    public Slider soundSlider;

    public void Start()
    {

        audioMixer.GetFloat("Music", out float musicValueForSlider);
        audioMixer.GetFloat("Sound", out float soundValueForSlider);
        audioMixer.SetFloat("Sound", -80f);
        musicSlider.value = musicValueForSlider;
        soundSlider.value = soundValueForSlider;

        //catch resolution of user without duplications
        resolutions = Screen.resolutions.Select(resolutionDropdown => new Resolution { width = resolutionDropdown.width, height = resolutionDropdown.height}).Distinct().ToArray();
        //clear defaut dropdown options
        resolutionDropdown.ClearOptions();
        //list of string where resolutions will be store
        List<string> options = new List<string>();
        //int for catching index of the resoution list when it's the playr resolution
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            //add string of resolution in option
            string option = resolutions[i].width + "x" + resolutions[i].height;
            //copy the string in the list of string
            options.Add(option);

            if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                //store the index of the resolution of the player
                currentResolutionIndex = i;
            }
        }

        //copy the list in the dropdown menu
        resolutionDropdown.AddOptions(options);
        //copy the value of the resolution
        resolutionDropdown.value = currentResolutionIndex;
        //refresh the display
        resolutionDropdown.RefreshShownValue();
    }
    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("Music", volume);
    }

    public void SetSoundVolume(float volume)
    {
        audioMixer.SetFloat("Sound", volume);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution =  resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

}
