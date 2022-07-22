using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forwardInput;
    public float speed = 20f;
    public float turnSpeed = 1f ;
    public float horizontalInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * Time.deltaTime * speed *forwardInput );
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * (Time.deltaTime*20));
       // transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * (horizontalInput * 20));
    }
}
