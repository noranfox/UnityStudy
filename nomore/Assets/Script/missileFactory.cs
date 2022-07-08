using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileFactory : MonoBehaviour
{
    public Rigidbody preafabmissile;
    public Transform fireTransform;
    private float timer = 10.0f;
    public float Shoot = 200.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        if (timer > Shoot)
        {
            Rigidbody missiles = Instantiate(preafabmissile, fireTransform.position, fireTransform.rotation);
            timer = 0;
        }

    }

}
