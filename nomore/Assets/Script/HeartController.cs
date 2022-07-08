using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour
{
    Rigidbody heart;
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        heart = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 turn = new Vector3(0, speed, 0);
        heart.AddTorque(turn * speed, ForceMode.Impulse);
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
