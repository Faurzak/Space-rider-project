using System;
using UnityEngine;

public class ReproducirMusica : MonoBehaviour
{
    [SerializeField] AudioClip musica;
    [SerializeField] AudioSource audioSource;

    private void Start()
    {
        if (audioSource != null)
        {
            audioSource.clip = musica;
            audioSource.Play();
        }
    }
}
