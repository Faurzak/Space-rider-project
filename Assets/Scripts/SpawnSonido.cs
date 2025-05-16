
using System;
using UnityEngine;

public class SpawnSonido : MonoBehaviour
{
    [SerializeField] AudioClip sonido;
    [SerializeField] AudioSource audioSource;
    
    private void Start()
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(sonido);
        }
        
        Destroy(gameObject, 5f);    
    }
}
