using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    public AudioMixer mixer;
    public string mixerParameter;

    public void OnValueChanged(float newValue)
    {
        float newVolume = Mathf.Log10(newValue) * 20;
        mixer.SetFloat(mixerParameter, newVolume);

        PlayerPrefs.SetFloat(mixerParameter, newVolume);
    }

    private void Start()
    {
        float savedValue = PlayerPrefs.GetFloat(mixerParameter);

        float newVolume = Mathf.Log10(savedValue) * 20;
        mixer.SetFloat(mixerParameter, newVolume);

        GetComponent<Slider>().value = savedValue;
    }
}
