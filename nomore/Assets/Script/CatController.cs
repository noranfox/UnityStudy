using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatController : MonoBehaviour
{
    Rigidbody player;
    public float speed = 0.0f;
    public float jumpPower = 0.0f;
    bool canJump;
    private int protect = 0;
               
// Start is called before the first frame update
void Start()
    {
        player = GetComponent<Rigidbody>();
        canJump = false;
    }



    void Move1()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            transform.localScale = new Vector3(1.0f, 1.0f, +1.0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.forward * -speed * Time.deltaTime);
            transform.localScale = new Vector3(1.0f, 1.0f, -1.0f);

        }
        transform.eulerAngles = new Vector3(0f, 90f , 0f);
    }
    void Jump1()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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
        
        //transform.eulerAngles = new Vector3(0f, 90, 0f);

    }
    void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag == "Item")
        {
            protect = 2;
        }
        if (coll.gameObject.tag == "Ground")
        {
            canJump = false;
        }
        if (coll.gameObject.tag == "Attack" )
        {
            if (protect <= 0)
            {
                // SceneManager.LoadScene("GameOver");
                Destroy(gameObject);
            }
            else if (protect > 0)
            {
                protect--;
            }
            
        }
    }
}
