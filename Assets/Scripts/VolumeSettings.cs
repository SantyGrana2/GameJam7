using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider soundSlider;

    public void SetSoundVolume()
    {
        float volume = soundSlider.value;
        myMixer.SetFloat ("music", volume);
    }
}
