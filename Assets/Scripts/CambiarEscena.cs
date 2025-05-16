using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    [SerializeField] GameObject uiJuego;
    [SerializeField] GameObject uiPausa;
    [SerializeField] string nombreEscenaMenuPrincipal;
    [SerializeField] float segundosParaCambiarEscena;
    
    private void Start()
    {
        uiJuego.SetActive(false);
        uiPausa.SetActive(false);
        Invoke("VolverAlMenuPrincipal", segundosParaCambiarEscena);
    }

    private void VolverAlMenuPrincipal()
    {
        SceneManager.LoadScene(nombreEscenaMenuPrincipal, LoadSceneMode.Single);
    }
}
