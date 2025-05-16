using System.Collections;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int vidaInicial = 100;
    [SerializeField] float velocidadMovimiento = 5f;
    [SerializeField] float ratioDisparoInicial = 0.5f;
    [SerializeField] GameObject disparoPrefab;
    [SerializeField] GameObject puntoDisparo1;
    [SerializeField] GameObject puntoDisparo2;
    [SerializeField] GameObject invulnerableSprite;
    [SerializeField] TMP_Text textoVidaPlayer;
    [SerializeField] GameObject uiPerderJuego;
    [SerializeField] GameObject explosionParticulasPrefab;
    [SerializeField] GameObject disparoParticulasPrefab;
    [SerializeField] GameObject impactoParticulasPrefab;
    [SerializeField] GameObject sonidoDisparo;
    [SerializeField] GameObject sonidoImpacto;
    [SerializeField] GameObject sonidoExplosion;
    
    private float temporizador = 10;
    private int vida;
    private float ratioDisparo;
    private bool invulnerable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vida = vidaInicial;
        ratioDisparo = ratioDisparoInicial;
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        DelimitarMovimiento();
    
        Disparar();
        TextoVidaPlayer();
    }

    private void DelimitarMovimiento()
    {
        float xClamped = Mathf.Clamp(transform.position.x, -8.35f, 8.35f);
        float yClamped = Mathf.Clamp(transform.position.y, -4.4f, 4.4f);
        transform.position = new Vector3(xClamped, yClamped, 0);
    }

    private void Movimiento()
    {
        float inputH = Input.GetAxisRaw("Horizontal");
        float inputV = Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector2(inputH, inputV).normalized * (velocidadMovimiento * Time.deltaTime));
    }

    private void Disparar(){
        temporizador += Time.deltaTime;

        if(Input.GetKey(KeyCode.Space) && temporizador > ratioDisparo){
            Instantiate(sonidoDisparo, transform.position, transform.rotation);
            Instantiate(disparoPrefab, puntoDisparo1.transform.position, Quaternion.identity);
            Instantiate(disparoParticulasPrefab, puntoDisparo1.transform.position, Quaternion.identity);
            Instantiate(disparoPrefab, puntoDisparo2.transform.position, Quaternion.identity);
            Instantiate(disparoParticulasPrefab, puntoDisparo2.transform.position, Quaternion.identity);
            temporizador = 0f;
        }
    }

    void OnTriggerEnter2D(Collider2D otro)
    {
        if(otro.gameObject.CompareTag("DisparoEnemigo") || otro.gameObject.CompareTag("Enemigo")){
            if (invulnerable == false) {
                vida -= 10;
            }
            Instantiate(sonidoImpacto, transform.position, transform.rotation);
            Instantiate(impactoParticulasPrefab, otro.gameObject.transform.position, Quaternion.identity);
            Destroy(otro.gameObject);
            
            if(vida <= 0)
            {
                uiPerderJuego.SetActive(true);
                Instantiate(sonidoExplosion, transform.position, transform.rotation);
                textoVidaPlayer.text = "Vida: 0";
                Instantiate(explosionParticulasPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }

        if (otro.gameObject.CompareTag("PowerUpCurarVida"))
        {
            CurarVida();
            Destroy(otro.gameObject);
        }

        if (otro.gameObject.CompareTag("PowerUpInvulnerable"))
        {
            StartCoroutine(ActivarInvulnerable());
            Destroy(otro.gameObject);
        }

        if (otro.gameObject.CompareTag("PowerUpDisparoRapido"))
        {
            StartCoroutine(ActivarDisparoRapido());
            Destroy(otro.gameObject);
        }
    }

    void TextoVidaPlayer()
    {
        textoVidaPlayer.text = "Vida: " + vida.ToString();
    }

    public void CurarVida()
    {
        vida = vidaInicial;
    }

    public IEnumerator ActivarInvulnerable()
    {
        invulnerable = true;
        invulnerableSprite.SetActive(true);
        yield return new WaitForSeconds(5f);
        invulnerable = false;
        invulnerableSprite.SetActive(false);
    }

    public IEnumerator ActivarDisparoRapido()
    {
        ratioDisparo = 0.1f;
        yield return new WaitForSeconds(5f);
        ratioDisparo = ratioDisparoInicial;
    }
}
