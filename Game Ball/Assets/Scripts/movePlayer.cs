using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movePlayer : MonoBehaviour
{

    private Rigidbody corpoPlayer;

    public float speedPlayer; //Controla a velocidade do Player
    public float jumpPlayer;
    private int vidas = 3;
    public int contadorItem;

    public Text textPontos;
    public Text textVitoria;
    public Text textVidas;
    public Text textDerrota;


    public Vector3 posInicial;




    // Start is called before the first frame update
    void Start()
    {
        corpoPlayer = GetComponent<Rigidbody>();
        contadorItem = 0;
        atualizaTextPontos();
        textVitoria.text = "";
        textVidas.text = "Vidas: " + vidas.ToString() + "x";

        posInicial = new Vector3(-3.63f, 0.21f, -74.368f);
        transform.position = posInicial;

    }


    private void Update()
    {

        if (transform.position.y <= -7)
        {

            Inicializar();
            vidas--;
            modVidas();
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        float movimentoH = Input.GetAxis("Horizontal");
        float movimentoV = Input.GetAxis("Vertical");

        Vector3 movimentoPlayer = new Vector3(movimentoH, 0, movimentoV);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            corpoPlayer.AddForce(new Vector3(0, jumpPlayer, 0), ForceMode.Impulse);
        }

        corpoPlayer.AddForce(movimentoPlayer * speedPlayer);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ItemColetavel"))
        {
            other.gameObject.SetActive(false);
            contadorItem++;
            atualizaTextPontos();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("AstroDano"))
        {
            collision.gameObject.SetActive(true);
            vidas--;
            modVidas();
            Derrota();
        }
    }

    void atualizaTextPontos()
    {
        textPontos.text = "Pontos: " + contadorItem;

        if (contadorItem >= 5)
        {
            textVitoria.text = "WIN YOU!";
        }

    }

    void Derrota()
    {
        if (vidas <= 0)
        {
            textDerrota.text = "GAME OVER";
        }
    }


    void modVidas()
    {
        textVidas.text = "Vidas: " + vidas.ToString() + "x";
    }

    public void Inicializar()
    {
       
        textVidas.text = "Vidas " + vidas.ToString();
        transform.position = posInicial;
    }
}
