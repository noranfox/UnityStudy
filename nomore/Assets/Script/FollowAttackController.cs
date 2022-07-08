using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAttackController : MonoBehaviour
{
    public float speed = 10.0f;
    Rigidbody Ak;
    GameObject target;
    private float timer = 1.0f;
    private float livetime = 5.0f;
    public ParticleSystem GrenadeExplosion;
    GameObject Pen;

    // Start is called before the first frame update
    void Start()
    {
        Ak = GetComponent<Rigidbody>();
        target = GameObject.Find("Cat");
        Pen = GameObject.Find("Penguin");
    }

    // Update is called once per frame
    void Update()
    {
        timer++;    
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);

        if (Pen == null)
        {
            Destroy(gameObject);
        }
    
    }

    private void OnCollisionEnter(Collision collision)
    {
        ParticleSystem brokenArrow = Instantiate(GrenadeExplosion, transform.position, transform.rotation);
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }

        else if (timer > livetime)
        {
            Destroy(gameObject);
            timer = 0.0f;
        }
    }
}
