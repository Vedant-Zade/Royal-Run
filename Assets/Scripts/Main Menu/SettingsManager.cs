using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider brightnessSlider;
    public Slider volumeSlider;
    
    public static float brightness = 1.0f;
    public static float volume = 0.5f;

    void Start()
    {
        if (PlayerPrefs.HasKey("Brightness"))
        {
            brightness = PlayerPrefs.GetFloat("Brightness");
            brightnessSlider.value = brightness;
        }
        
        if (PlayerPrefs.HasKey("Volume"))
        {
            volume = PlayerPrefs.GetFloat("Volume");
            volumeSlider.value = volume;
            AudioListener.volume = volume;
        }

        brightnessSlider.onValueChanged.AddListener(UpdateBrightness);
        volumeSlider.onValueChanged.AddListener(UpdateVolume);
    }

    public void UpdateBrightness(float value)
    {
        brightness = value;
        RenderSettings.ambientLight = Color.white * brightness;
        PlayerPrefs.SetFloat("Brightness", brightness);
        PlayerPrefs.Save();
    }

    public void UpdateVolume(float value)
    {
        volume = value;
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }
}
