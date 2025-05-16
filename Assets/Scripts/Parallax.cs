using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float anchoImagen;
    [SerializeField] private Vector3 direccion;
    
    private Vector3 _posicionInicial;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _posicionInicial =  transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        float resto = (velocidad * Time.time) % anchoImagen;
        transform.position = _posicionInicial + direccion * resto;
    }
}
