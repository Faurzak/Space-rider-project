using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Enemigo2 : MonoBehaviour 
{
    [SerializeField] int vida = 50;
    [SerializeField] Vector3 direccionMovimiento;
    [SerializeField] float velocidadMovimiento = 1.5f;
    [SerializeField] GameObject disparoPrefab1;
    [SerializeField] GameObject disparoPrefab2;
    [SerializeField] GameObject puntoDisparo1;
    [SerializeField] GameObject puntoDisparo2;
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
        StartCoroutine(MovimientoUpDown());
        StartCoroutine(Disparar());
        Destroy(gameObject, 30f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direccionMovimiento * (velocidadMovimiento * Time.deltaTime));
    }

    private IEnumerator MovimientoUpDown()
    {
        while (true)
        {
            direccionMovimiento.y = 1f;
            yield return new WaitForSeconds(1.5f);
            direccionMovimiento.y = -1f;
            yield return new WaitForSeconds(1.5f);
        }
    }
    
    private IEnumerator Disparar(){
        while (true)
        {
            Instantiate(sonidoDisparo, transform.position, transform.rotation);
            Instantiate(disparoPrefab1, puntoDisparo1.transform.position, disparoPrefab1.transform.rotation);
            Instantiate(disparoParticulasPrefab, puntoDisparo1.transform.position, Quaternion.identity);
            Instantiate(disparoPrefab2, puntoDisparo2.transform.position, disparoPrefab2.transform.rotation);
            Instantiate(disparoParticulasPrefab, puntoDisparo2.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(3f);
        } 
    }

    void OnTriggerEnter2D(Collider2D otro)
    {
        if(otro.gameObject.CompareTag("DisparoPlayer")){
            vida -= 10;
            Instantiate(sonidoImpacto, transform.position, transform.rotation);
            Instantiate(impactoParticulasPrefab, otro.gameObject.transform.position, Quaternion.identity);
            Destroy(otro.gameObject);
            
            if(vida <= 0){
                Instantiate(sonidoExplosion, transform.position, transform.rotation);
                Instantiate(spawnPowerUpPrefab, transform.position, Quaternion.identity);
                Instantiate(explosionParticulasPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}