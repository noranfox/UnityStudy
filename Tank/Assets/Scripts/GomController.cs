using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GomController : MonoBehaviour
{
    public Rigidbody mog;
    public Transform fireTransform;
    public float ShootSpeed;
    public int playerNum = 1;
    public float remonster = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        remonster++;

        if (remonster == 100)
        {
            Rigidbody GomInstance =
            Instantiate(mog, fireTransform.position, fireTransform.rotation) as Rigidbody;

            //Æ÷Åº¹ß»ç
            GomInstance.velocity = ShootSpeed * fireTransform.forward;
            remonster = 0;
        }
    }
}
