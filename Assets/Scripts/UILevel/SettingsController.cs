using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public UnityEngine.UI.Slider sensitivitySlider;
    public UnityEngine.UI.Slider volumeSlider;

    public float sensitivity = 200f;

    void Start()
    {
        sensitivitySlider.onValueChanged.AddListener(SetSensitivity);
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    void SetSensitivity(float value)
    {
        sensitivity = value;
    }

    void SetVolume(float value)
    {
        AudioListener.volume = value;
    }
}