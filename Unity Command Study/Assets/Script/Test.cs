using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    Rigidbody Coin;
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        Coin = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void FixedUpdate()
    {
        Vector3 vec = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Jump"),Input.GetAxis("Vertical"));
        Coin.AddForce(vec, ForceMode.Impulse);
        Coin.AddTorque(0,1,0);
        //transform.Traslate(vec * speed);
    }
}
