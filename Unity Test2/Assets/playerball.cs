using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerball : MonoBehaviour
{
    public float speed = 5.0f;


    Vector3 startPos;
    private Rigidbody playerRi;

    // Start is called before the first frame update
    void Start()
    {
        playerRi = GetComponent<Rigidbody>();
        playerRi.AddForce(-speed, 0f, speed * 0.7f);
        startPos = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            Vector3 currPos = collision.transform.position;
            Vector3 incomVec = currPos - startPos; //�Ի簢
            Vector3 normalVec = collision.contacts[0].normal; //��������
            Vector3 reflectVec = Vector3.Reflect(incomVec, normalVec); //�ݻ簢

            reflectVec = reflectVec.normalized; //�ݻ簢 ����ȭ

            playerRi.AddForce(reflectVec * speed);
        }
        startPos = transform.position;

    }
}
