using UnityEngine;

public class Disparo : MonoBehaviour
{
    [SerializeField] float velocidadDisparo = 3f;
    [SerializeField] Vector3 direccion;
    [SerializeField] float tiempoDestruccion = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, tiempoDestruccion);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direccion * (velocidadDisparo * Time.deltaTime));
    }
}
