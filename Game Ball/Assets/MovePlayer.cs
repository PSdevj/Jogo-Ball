using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{

    private CharacterController controllerplayer;
    private Animator anim;

    public float speedPlayer; //Controla a velocidade do Player
    private Vector3 inputsPlayer; //Receberá os valores dos teclados
    private Vector3 jump; 
    public float jumpPlayer; //Controla o pulo do Player
   

    // Start is called before the first frame update
    void Start()
    {
        controllerplayer = GetComponent<CharacterController>();
        jump = new Vector3(0f, 2.0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        inputsPlayer.Set(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controllerplayer.Move(inputsPlayer * Time.deltaTime * speedPlayer);
        controllerplayer.Move(Vector3.down * Time.deltaTime);
    }
}
