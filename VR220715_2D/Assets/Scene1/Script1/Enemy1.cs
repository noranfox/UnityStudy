using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1f ;
    public float healt;
    
    public Sprite[] sprites;
    SpriteRenderer spriteRenderer;

    Rigidbody2D rb;

    public float curBulletDelay = 0f;
    public float maxBulletDelay;
    public GameObject goBullet;
    public GameObject goPlayer;
    public GameManager manager;
    public ObjectManager objmanager;
   


    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
       // rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
       // rb.velocity = Vector2.down * speed;
    }
    // Update is called once per frame
    void Update()
    {
        Fire();
        ReloadBullet();
    }

    void Fire()
    {
        if(curBulletDelay < maxBulletDelay)
        { return; }
        //GameObject createBullet = Instantiate(goBullet, transform.position, Quaternion.identity);
        GameObject createBullet = objmanager.MakeObject("EnemyBullet");
        createBullet.transform.position = transform.position;

        Rigidbody2D rd = createBullet.GetComponent<Rigidbody2D>();

        Vector3 dirVec = goPlayer.transform.position - transform.position;
        rd.AddForce(dirVec.normalized * 1, ForceMode2D.Impulse);
        //transform.position = Vector2.MoveTowards()
        curBulletDelay = 0;
    }

    void ReloadBullet()
    {
        curBulletDelay += Time.deltaTime;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            //int randPoint = Random.Range(0, 3);
            gameObject.SetActive(false);
           // gameObject.transform.position = manager.spawnPoints[randPoint].position;

        }
   
        else if (collision.gameObject.tag == "PlayerBullet" ) 
        {
            Bullet1 bullet = collision.gameObject.GetComponent<Bullet1>();
            OnHit(bullet.power);
            collision.gameObject.SetActive(false);
            collision.gameObject.transform.position = goPlayer.transform.position;
        }
    }
  
    void ReturnSprite()
    {
        spriteRenderer.sprite = sprites[0];
    }

    void OnHit(float playerBulletPower)
    {
        healt -= playerBulletPower;
        spriteRenderer.sprite = sprites[1];
       
        
        Invoke("ReturnSprite", 0.1f);  // startcouroutine 으로도 가능. 

        if (healt <= 0)
        {
            //int randPoint = Random.Range(0, 3);
            gameObject.SetActive(false);
            //gameObject.transform.position = manager.spawnPoints[randPoint].position;
        }
    }
    private void OnEnable()
    {
        healt = 3;
    }
}
