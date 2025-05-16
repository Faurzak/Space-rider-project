using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumenSlider : MonoBehaviour
{
    [SerializeField] AudioMixer masterAudioMixer;
    [SerializeField] Slider volumenSlider;

    private void Update()
    {
        CambiarVolumen();
    }

    public void CambiarVolumen()
    {
        masterAudioMixer.SetFloat("Volumen", Mathf.Log10(volumenSlider.value) * 20);
    }
}
