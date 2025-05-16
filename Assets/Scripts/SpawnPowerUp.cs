using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnPowerUp : MonoBehaviour
{
    [SerializeField] GameObject powerUpCurarVidaPrefab;
    [SerializeField] GameObject powerUpInvulnerablePrefab;
    [SerializeField] GameObject powerUpDisparoRapidoPrefab;
    [SerializeField] private float probabilidadSpawnearPowerUp = 0.6f; 
    
    private void Start()
    {
        Destroy(gameObject, 5f);
        ElegirPowerUp();
    }

    private void ElegirPowerUp()
    {
        int powerUpElegido = Random.Range(0, 4);
        float probabilidadSpawn = Random.Range(0f, 1f);

        if (probabilidadSpawn <= probabilidadSpawnearPowerUp)
        {
            if (powerUpElegido == 0)
            {
                Instantiate(powerUpCurarVidaPrefab, transform.position, transform.rotation);
            }
            if (powerUpElegido == 1)
            {
                Instantiate(powerUpInvulnerablePrefab, transform.position, transform.rotation);
            }
            if (powerUpElegido == 2)
            {
                Instantiate(powerUpDisparoRapidoPrefab, transform.position, transform.rotation);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
