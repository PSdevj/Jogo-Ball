using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Rigidbody corpoPlayer;
    public float speedPlayer;


    // Start is called before the first frame update
    void Start()
    {
        corpoPlayer = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovPlayer();
    }
   
    void MovPlayer()
    {
        speedPlayer = Input.GetAxis("Horizontal");
        corpoPlayer.velocity = new Vector2(speedPlayer, corpoPlayer.velocity.y);
    }
}
