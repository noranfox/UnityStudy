using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10.0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, speed));
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
