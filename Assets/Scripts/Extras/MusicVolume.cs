using UnityEngine;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour
{
    public Slider volumeSlider;

    private void Start()
    {
        // Set the slider value to match the current volume
        volumeSlider.value = AudioManager.Instance.audioSource.volume;
        volumeSlider.onValueChanged.AddListener(UpdateVolume);
    }

    
    public void UpdateVolume(float value)
    {
        AudioManager.Instance.SetVolume(value); // Update the volume in the AudioManager
    }
}
