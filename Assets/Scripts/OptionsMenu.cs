using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{

    public AudioMixer masterMixer;

    public AudioSource music;

    public Dropdown resolutionDropdown;

    public Image D, F, J, K;

    Color keycapColor;

    Resolution[] resolutions;
     

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for(int i=0; i<resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = 1;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        keycapColor = new Color(175, 63, 1);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            D.color = Color.red;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            D.color = Color.white;
        }

        if (Input.GetKey(KeyCode.F))
        {
            F.color = Color.red;
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            F.color = Color.white;
        }

        if (Input.GetKey(KeyCode.J))
        {
            J.color = Color.red;
        }
        else if (Input.GetKeyUp(KeyCode.J))
        {
            J.color = Color.white;
        }

        if (Input.GetKey(KeyCode.K))
        {
            K.color = Color.red;
        }
        else if (Input.GetKeyUp(KeyCode.K))
        {
            K.color = Color.white;
        }
    }
    public void SetMasterVolume(float masterVolume)
    {
        masterMixer.SetFloat("Master_Volume", masterVolume);
    }

    public void SetMusicVolume(float musicVolume)
    {
        music.volume = musicVolume;
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen; 
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
