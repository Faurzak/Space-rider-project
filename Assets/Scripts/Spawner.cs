using System.Collections;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemigoPrefab1;
    [SerializeField] GameObject enemigoPrefab2;
    [SerializeField] GameObject enemigoPrefab3;
    [SerializeField] float retrasoEntreSpawns = 1.5f;
    [SerializeField] TMP_Text textoNivelOleadas;
    [SerializeField] int cantidadEnemigos = 10;
    [SerializeField] int cantidadOleadas = 5;
    [SerializeField] int cantidadNiveles = 5;
    [SerializeField] GameObject uiGanarJuego;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnearEnemigos());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnearEnemigos(){
        for (int nivel = 0; nivel < cantidadNiveles; nivel++)
        {
            for (int oleada = 0; oleada < cantidadOleadas; oleada++)
            {
                textoNivelOleadas.text = "Nivel: " + (nivel + 1) + " - Oleada: " + (oleada + 1);
                yield return new WaitForSeconds(3f);
                textoNivelOleadas.text = "";

                for (int enemigo = 0; enemigo < cantidadEnemigos + nivel + oleada; enemigo++)
                {
                    Vector3 puntoAleatorio = new Vector3(transform.position.x, Random.Range(-4.4f, 4.4f), 0f);

                    if (nivel == 0)
                    {
                        Instantiate(enemigoPrefab1, puntoAleatorio, Quaternion.identity);
                    }
                    if (nivel == 1)
                    {
                        int tipoEnemigo = Random.Range(0, 2);

                        if(tipoEnemigo == 0)
                        {
                            Instantiate(enemigoPrefab1, puntoAleatorio, Quaternion.identity);
                        }
                        if(tipoEnemigo == 1)
                        {
                            Instantiate(enemigoPrefab2, puntoAleatorio, Quaternion.identity);
                        }
                    }
                    if (nivel >= 2)
                    {
                        int tipoEnemigo = Random.Range(0, 3);

                        if(tipoEnemigo == 0)
                        {
                            Instantiate(enemigoPrefab1, puntoAleatorio, Quaternion.identity);
                        }
                        if(tipoEnemigo == 1)
                        {
                            Instantiate(enemigoPrefab2, puntoAleatorio, Quaternion.identity);
                        }
                        if(tipoEnemigo == 2)
                        {
                            Instantiate(enemigoPrefab3, puntoAleatorio, Quaternion.identity);
                        }
                    }
                    
                    yield return new WaitForSeconds(retrasoEntreSpawns);
                }

                yield return new WaitForSeconds(5f);
            }

            yield return new WaitForSeconds(5f);
        }
        
        uiGanarJuego.SetActive(true);
    }
}
