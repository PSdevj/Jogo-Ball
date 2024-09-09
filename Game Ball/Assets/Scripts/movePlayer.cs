using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movePlayer : MonoBehaviour
{

    private Rigidbody corpoPlayer;

    public float speedPlayer; //Controla a velocidade do Player
    public float jumpPlayer;

    public int contadorItem;

    public Text textPontos;
    public Text textVitoria;

   

    // Start is called before the first frame update
    void Start()
    {
        corpoPlayer = GetComponent<Rigidbody>();
        contadorItem = 0;
        atualizaTextPontos();
        textVitoria.text = "";
    }


    private void Update()
    {
        
        if(transform.position.y <= -7)
        {
            Application.LoadLevel("Jogo");
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

    void atualizaTextPontos()
    {
        textPontos.text = "Pontos: " + contadorItem;

        if(contadorItem >= 1)
        {
            textVitoria.text = "WIN YOU!";
        }

    }
}
