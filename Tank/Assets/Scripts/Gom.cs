using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gom : MonoBehaviour
{

    Rigidbody GomRi;
    public float Damage = 50.0f;
    public float Hp = 100.0f;
    public ParticleSystem tankExplosion;
    private float timer = 1.0f;
    public float MonsterTurn = 100;

    // S
    // tart is called before the first frame update
    void Start()
    {
        
    }
    IEnumerator MoveObject()
    {
        timer++;
        GomRi = GetComponent<Rigidbody>();
        while(timer == MonsterTurn )
        {
            float pop1 =  Random.Range(-50.0f, 50.0f); 
            float pop2 = Random.Range(-50.0f, 50.0f);
            float pop3 = Random.Range(-50.0f, 50.0f);
            
            yield return new WaitForSeconds(2);
            GomRi.velocity = new Vector3(pop1,0f,pop3);
            timer =0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(MoveObject());
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

