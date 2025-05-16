using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Enemigo : MonoBehaviour 
{
    [SerializeField] int vida = 20;
    [SerializeField] Vector3 direccionMovimiento;
    [SerializeField] float velocidadMovimiento = 2.5f;
    [SerializeField] GameObject disparoPrefab;
    [SerializeField] GameObject puntoDisparo;
    [SerializeField] GameObject spawnPowerUpPrefab;
    [SerializeField] GameObject explosionParticulasPrefab;
    [SerializeField] GameObject disparoParticulasPrefab;
    [SerializeField] GameObject impactoParticulasPrefab;
    [SerializeField] GameObject sonidoDisparo;
    [SerializeField] GameObject sonidoImpacto;
    [SerializeField] GameObject sonidoExplosion;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Disparar());
        Destroy(gameObject, 30f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direccionMovimiento * (velocidadMovimiento * Time.deltaTime));
    }


    private IEnumerator Disparar(){
        while (true)
        {
            Instantiate(sonidoDisparo, transform.position, transform.rotation);
            Instantiate(disparoPrefab, puntoDisparo.transform.position, Quaternion.identity);
            Instantiate(disparoParticulasPrefab, puntoDisparo.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1.5f);
        }
    }

    void OnTriggerEnter2D(Collider2D otro)
    {
        if(otro.gameObject.CompareTag("DisparoPlayer")){
            vida -= 10;
            Instantiate(sonidoImpacto, transform.position, transform.rotation);
            Instantiate(impactoParticulasPrefab, otro.gameObject.transform.position, Quaternion.identity);
            Destroy(otro.gameObject);
            
            if(vida <= 0)
            {
                Instantiate(sonidoExplosion, transform.position, transform.rotation);
                Instantiate(spawnPowerUpPrefab, transform.position, Quaternion.identity);
                Instantiate(explosionParticulasPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}