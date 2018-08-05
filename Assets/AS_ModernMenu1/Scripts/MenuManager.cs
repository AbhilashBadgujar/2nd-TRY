using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour {
    public AudioMixer audioMixer;
    Resolution[] resulutions;
    public Dropdown resulutionDropdown;
    public GameObject menupanel;
    public GameObject settingspanel;
    public GameObject creaditspanel;
    // Use this for initialization
    void Start()
    {
        resulutions = Screen.resolutions;

        resulutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resulutions.Length; i++)
        {
            string option = resulutions[i].width + "x" + resulutions[i].height;
            options.Add(option);
            if (resulutions[i].width == Screen.currentResolution.width && resulutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resulutionDropdown.AddOptions(options);
        resulutionDropdown.value = currentResolutionIndex;
        resulutionDropdown.RefreshShownValue();
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resulutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height,Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetFullscreen(bool isfullscreen)
    {
        Screen.fullScreen = isfullscreen;
    }

	// Update is called once per frame
	void Update () {
		
	}
   public void menumanager(GameObject other)
    {
        if (other.name == "settings_button")
        {
            menupanel.SetActive(false);
            settingspanel.SetActive(true);
        }
        if (other.name == "creadits_button")
        {
            creaditspanel.SetActive(true);
            menupanel.SetActive(false);
        }
        if (other.name == "exit_button")
        {
            Application.Quit();
            Debug.Log("Exit");
        }
        if (other.name == "back_button")
        {
            settingspanel.SetActive(false);
            menupanel.SetActive(true);
        }
        if (other.name == "back_Button")
        {
            creaditspanel.SetActive(false);
            menupanel.SetActive(true);
        }
    }
}
