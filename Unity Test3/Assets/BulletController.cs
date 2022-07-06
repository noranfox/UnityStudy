using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10.0f;
    GameObject player;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Shoottotarget()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, speed*2));
        }

    }
    public void ShoottoPlayer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            player = GameObject.Find("Player");

            Vector3 dir = player.transform.position - this.transform.position;
            GetComponent<Rigidbody>().AddForce(dir * speed /10);
        }

    }
    public void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "Enemy")
        {
            GameObject manager = GameObject.Find("ScoreManager");
            manager.GetComponent<scorescript>().IncScore();
    
            // �Ѿ� �ı�
            Destroy(gameObject);
        }
        if (coll.collider.tag == "target1")
        {
            GameObject manager = GameObject.Find("ScoreManager");
            manager.GetComponent<scorescript>().IncScore1();

            // �Ѿ� �ı�
            Destroy(gameObject);
        }
        if (coll.collider.tag == "target2")
        {
            GameObject manager = GameObject.Find("ScoreManager");
            manager.GetComponent<scorescript>().IncScore2();

            // �Ѿ� �ı�
            Destroy(gameObject);
        }
        if (coll.collider.tag == "target3")
        {
            GameObject manager = GameObject.Find("ScoreManager");
            manager.GetComponent<scorescript>().IncScore3();

            // �Ѿ� �ı�
            Destroy(gameObject);
        }
    }
}
