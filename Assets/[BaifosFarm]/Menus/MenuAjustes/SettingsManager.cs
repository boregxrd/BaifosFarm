using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SettingsManager : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    public Dropdown qualityDropdown;

    void Start()
    {
        InitResolutionDropdown();
        InitQualityDropdown();
    }

    void InitResolutionDropdown()
    {
        resolutionDropdown.ClearOptions();
        // Updated the list of resolutions
        List<string> options = new List<string>() 
        { 
            "3840 x 2160", 
            "2560 x 1440", 
            "1920 x 1080", 
            "1366 x 768", 
            "1280 x 720", 
            "800 x 600" 
        };
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.onValueChanged.AddListener(SetResolution);

        // Set default resolution to 1920 x 1080
        int defaultIndex = options.IndexOf("1920 x 1080");
        resolutionDropdown.value = defaultIndex;
        resolutionDropdown.RefreshShownValue();
        SetResolution(defaultIndex);  // Apply the default resolution immediately
    }

    void InitQualityDropdown()
    {
        qualityDropdown.ClearOptions();
        qualityDropdown.AddOptions(new List<string> { "Baja", "Media", "Alta" });
        qualityDropdown.onValueChanged.AddListener(SetQuality);
    }

    public void SetResolution(int index)
    {
        Debug.Log($"Changing resolution to index: {index}");
        Resolution resolution = new Resolution();
        switch (index)
        {
            case 0:
                resolution.width = 3840;
                resolution.height = 2160;
                break;
            case 1:
                resolution.width = 2560;
                resolution.height = 1440;
                break;
            case 2:
                resolution.width = 1920;
                resolution.height = 1080;
                break;
            case 3:
                resolution.width = 1366;
                resolution.height = 768;
                break;
            case 4:
                resolution.width = 1280;
                resolution.height = 720;
                break;
            case 5:
                resolution.width = 800;
                resolution.height = 600;
                break;
        }
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int index)
    {
        Debug.Log($"Setting quality level to index: {index}");
        QualitySettings.SetQualityLevel(index, true);
    }
}
