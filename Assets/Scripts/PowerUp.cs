using System;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] Vector3 direccionMovimiento;
    [SerializeField] float velocidadMovimiento;
    private void Start()
    {
        Destroy(gameObject, 30f);
    }

    private void Update()
    {
        transform.Translate(direccionMovimiento * (velocidadMovimiento * Time.deltaTime));
    }
}
