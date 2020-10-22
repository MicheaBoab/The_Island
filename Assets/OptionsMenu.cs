using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Dropdown resolutionDropdown;
    public Toggle fullScreenToggle;
    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;        

        List<string> options= new List<string>();
        int currentResolutionIndex = 0;

        for (int i= 0; i< resolutions.Length; i++){
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].Equals(Screen.currentResolution)) {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.ClearOptions();
        resolutionDropdown.AddOptions(options);

        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        //fullScreenToggle.isOn = Screen.fullScreen;
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex){
        Resolution res = resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
}
