using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovePlayer : MonoBehaviour
{
    private CharacterController controllerPlayer;
    private Animator anim;



    public float speedPlayer;
    public float gravityPlayer;


    private Vector3 moveDirection;
    private float rot;
    public float rotSpeed;


    // Start is called before the first frame update
    void Start()
    {
        controllerPlayer = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MovPlayer();
    }
   
    void MovPlayer()
    {
        if (controllerPlayer.isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                moveDirection = Vector3.forward * speedPlayer;
                anim.SetInteger("transition", 1);

            }


            if (Input.GetKeyUp(KeyCode.W))
            {
                moveDirection = Vector3.zero * speedPlayer;
                anim.SetInteger("transition", 0);
            }
        }

        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        moveDirection = transform.TransformDirection(moveDirection);
        transform.eulerAngles = new Vector3(0, rot, 0); //o persongame irá rotacionar somente no eixo Z
        moveDirection.y -= gravityPlayer * Time.deltaTime;


        controllerPlayer.Move(moveDirection * Time.deltaTime);

    }
}
