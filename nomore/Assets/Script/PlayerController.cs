using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody player;
    public float speed = 0.0f;
    public float jumpPower = 0.0f;
    float mouseX = 0;
    bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
        canJump = false;
    }



    void Move1()
    {
        float playermv = Input.GetAxis("Horizontal1");
        float playerro = Input.GetAxis("Vertical1");

        Vector3 move = new Vector3(playermv, 0f, playerro);
        transform.Translate(move * speed * Time.deltaTime);


    }
    void Jump1()
    {
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            if (canJump == false)
            {
                player.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
                canJump = true;
            }
        }

    }
    void Update()
    {
        
        Jump1();
        Move1();
        mouseX += Input.GetAxis("Mouse X") * 10;
        transform.eulerAngles = new Vector3(0f, mouseX, 0f);
        Debug.Log($"bool : {canJump}");
    }
    void OnCollisionEnter(Collision coll)
    {
        
        if(coll.gameObject.tag == "Ground" )
        {
            canJump = false ; 
        }
       
    }
}
