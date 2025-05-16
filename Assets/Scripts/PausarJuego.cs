using System;
using UnityEngine;

public class PausarJuego : MonoBehaviour
{
    [SerializeField] GameObject uiPausa;
    [SerializeField] GameObject uiJuego;

    private bool estaPausado;
    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (estaPausado == false)
            {
                estaPausado = true;
                Pausar();
            }
            else if (estaPausado == true)
            {
                estaPausado = false;
                Reanudar();
            }
        }
    }

    public void Reanudar()
    {
        uiPausa.SetActive(false);
        uiJuego.SetActive(true);
        Time.timeScale = 1f;
    }

    public void Pausar()
    {
        uiPausa.SetActive(true);
        uiJuego.SetActive(false);
        Time.timeScale = 0f;
    }
}
