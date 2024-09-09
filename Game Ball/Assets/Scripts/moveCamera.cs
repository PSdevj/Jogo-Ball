using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour
{

    public GameObject playerCam;
    private Vector3 offSet;

    // Start is called before the first frame update
    void Start()
    {
        offSet = transform.position - playerCam.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerCam.transform.position + offSet;
    }
}
