using UnityEngine;
using UnityEngine.SceneManagement;

public class JugarBoton : MonoBehaviour
{
    [SerializeField] private string nombreEscenaJuego;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EmpezarJuego()
    {
        SceneManager.LoadScene(nombreEscenaJuego, LoadSceneMode.Single);
    }
}
