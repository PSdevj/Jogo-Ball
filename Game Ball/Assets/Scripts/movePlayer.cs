using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movePlayer : MonoBehaviour
{

    private Rigidbody corpoPlayer;

    public float speedPlayer; //Controla a velocidade do Player
    private int vidas = 3;
    public int contadorItem;

    public Text textPontos;
    public Text textVitoria;
    public Text textVidas;
    public Text textDerrota;

    private Vector3 movimentoPlayer;
    public Vector3 posInicial;

    public ControleDoJogo genJ;



    // Start is called before the first frame update
    void Start()
    {
        corpoPlayer = GetComponent<Rigidbody>();
        contadorItem = 0;
        atualizaTextPontos();
        textVitoria.text = "";
        textVidas.text = "Vidas: " + vidas.ToString() + "x";

        posInicial = new Vector3(-3.63f, 5.439f, -14.268f);
        transform.position = posInicial;

        genJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<ControleDoJogo>();

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

        movimentoPlayer = new Vector3(movimentoH, 0, movimentoV);

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
            genJ.JogadorVenceu();
        }

    }

    void Derrota()
    {
        if (vidas <= 0)
        {
            textDerrota.text = "GAME OVER";
            genJ.PersonagemMorreu();
         
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
