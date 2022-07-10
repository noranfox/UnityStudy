using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    public float maxspeed = 1;
    Animator Move;
    SpriteRenderer flip;
    public float jump = 10;

    Rigidbody2D Player;
    // Start is called before the first frame update
    void Awake()
    {
        Player = GetComponent<Rigidbody2D>();
        Move = GetComponent<Animator>();
        flip = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void horizon()
    {
        float move = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector2.right * move * speed * Time.deltaTime);

        /*Player.AddForce(Vector2.right * move * speed, ForceMode2D.Impulse);
    if (Player.velocity.x > maxspeed) //오른쪽최대속도
    {
    Player.velocity = new Vector2(maxspeed, Player.velocity.y);
    }
    else if (Player.velocity.x< maxspeed*(-1)) //왼쪽최대속도
    {
    Player.velocity = new Vector2(maxspeed*(-1), Player.velocity.y);
    }*/



        if (Input.GetAxisRaw("Horizontal") == -1)
        {
             flip.flipX = true;
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            flip.flipX = false;
        }
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            Move.SetBool("isMoving", true);
        }
        else if(Input.GetAxisRaw("Horizontal") == 0)
        {
            Move.SetBool("isMoving", false);
        }

    }
   
    void Jump ()
    {
        if(Input.GetButtonDown("Jump") && !Move.GetBool("isJumping"))
        {
            Player.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            Move.SetBool("isJumping", true);

        }
        //Landing Platform

        Debug.DrawRay(Player.position, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(Player.position, Vector3.down, 1, LayerMask.GetMask("Floor"));
        do
        {
            Player.velocity *= 2;
        }
        while (Player.velocity.y > 0);
        {

        }
        if (Player.velocity.y < 0)
        {
      

            if (rayHit.collider != null)
            {
                if (rayHit.distance < 1f)
                {
                    Move.SetBool("isJumping", false);
                }

            }

        }
    }
    void Update()
    {
        
        horizon();
        Jump();
       



    }
}

