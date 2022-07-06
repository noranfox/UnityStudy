using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gom : MonoBehaviour
{
    public float turn = 1.0f;
    Rigidbody GomRi;
    private float pop1 =  Random.Range(-1.0f, 2.0f);
    private float pop2 = Random.Range(-1.0f, 2.0f);

    public float Damage = 50.0f;
    public float Hp = 100.0f;
    public ParticleSystem tankExplosion;

    // S
    // tart is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        turn++;
        if (turn > 100)
        {   
            GomRi.AddForce(new Vector3(pop1, 0f, pop2));
            turn = 0;
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        ParticleSystem Fired = Instantiate(tankExplosion, transform.position, transform.rotation);
        if (collision.gameObject.tag == "shell")
        {
            Debug.Log("Hit");
            Hp -= Damage;
        }
        if (Hp <= 0)
        {

            Fired.Play();
            Destroy(gameObject);
            // Destroy(Fired.gameObject);
        }

    }
}

