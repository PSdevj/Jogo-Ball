using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{

    private Rigidbody corpoPlayer;

    public float speedPlayer; //Controla a velocidade do Player
    public float jumpPlayer;

    private int contadorItem;
  
   

    // Start is called before the first frame update
    void Start()
    {
        corpoPlayer = GetComponent<Rigidbody>();
        contadorItem = 0;
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
        }
    }
}
