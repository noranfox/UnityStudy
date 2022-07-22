using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MovingObject
{

    public int wallDamage =1;
    public int pointsPerFood = 10;
    public int pointsPerSoda = 20;
    public float restartLevelDalay = 1f;

    public AudioClip moveSound1;
    public AudioClip moveSound2;
    public AudioClip eatSound1;
    public AudioClip eatSound2;
    public AudioClip drinkSound1;
    public AudioClip drinkSound2;
    public AudioClip gameOverSound;


    private Vector2 touchOrigin = -Vector2.one;

    private Animator animator;
    private int food;
    public Text foodText;

    Rigidbody2D rb2;
    SpriteRenderer spriteRenderer;

    protected override void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        food = GameManager.instance.playerFoodPoints;

        foodText.text ="Food:"+food;

        base.Start();
    }

    private void OnDisable()
    {
        GameManager.instance.playerFoodPoints = food;
    }

    void Update()
    {
        if(!GameManager.instance.playersTurn) return;
         
        int horizontal = 0;
        int vertical = 0;

   // #if UNITY_STANDALONE || UNITY_WEBPLAYER

        horizontal = (int) Input.GetAxisRaw("Horizontal");
        vertical = (int) Input.GetAxisRaw("Vertical");

        if (horizontal != 0)
        {
            vertical = 0;
            
        }

  //  #else
        if(Input.touchCount > 0)
        {
            Touch myTouch =Input.touches[0];

            if(myTouch.phase == TouchPhase.Began)
            {
                touchOrigin = myTouch.position;
            }
            
            else if(myTouch.phase == TouchPhase.Ended && touchOrigin.x >= 0)
            {
                Vector2 touchEnd = myTouch.position;
                float x = touchEnd.x - touchOrigin.x;
                float y = touchEnd.y - touchOrigin.y;
                touchOrigin.x = -1;
                if(Mathf.Abs(x) > Mathf.Abs(y))
                {
                    horizontal = x > 0 ? 1 : -1;
                }
                else
                {
                    vertical = y > 0? 1: -1;
                }
            }
        }
   //     #endif




        if (horizontal != 0 || vertical != 0)
        {
            if(horizontal == 1)
            {
                spriteRenderer.flipX =false;
            }
            if(horizontal == -1 )
            {
                spriteRenderer.flipX = true;
            }
            AttemptMove<Wall>(horizontal, vertical);
        }

    }

    protected override void AttemptMove <T> (int xDir, int yDir)
    {
        food --;
        foodText.text ="Food:"+food;
        base.AttemptMove <T> (xDir, yDir);
        RaycastHit2D hit;
        if(Move (xDir, yDir, out hit))
        {
            SoundManager.instance.RandomizeSfx(moveSound1,moveSound2);
        }
        CheckIfGameOver();
        GameManager.instance.playersTurn =false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Exit")    
        {
        Invoke("Restart", restartLevelDalay);
        enabled = false;
        }
        else if (other.tag == "Food")
        {
            food += pointsPerFood;
            foodText.text = "+" + pointsPerFood + "Food:" + food;
            SoundManager.instance.RandomizeSfx(eatSound1, eatSound2);
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "Soda")
        {
            food += pointsPerSoda;
            foodText.text = "+" + pointsPerSoda + "Food:" + food;
            SoundManager.instance.RandomizeSfx(drinkSound1, drinkSound2);
            other.gameObject.SetActive(false);
        }

    }

    protected override void OnCantMove <T> (T component)
    {
        Wall hitWall = component as Wall;
        hitWall.DamageWall(wallDamage);
        animator.SetTrigger("playerChop");
    }

    private void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void LossFood (int loss)
    {
        animator.SetTrigger("playerHit");
        food -= loss;
        foodText.text = "-" + loss + "Food:" + food;
        CheckIfGameOver();
    }

    private void CheckIfGameOver()
    {
        if(food <=0)
        {
            SoundManager.instance.PlaySingle(gameOverSound);
            GameManager.instance.GameOver();
            Restart();
            
            GameManager.instance.Regame();
            food = 100;
            foodText.text = "Food:" + food;
        }
    }
}
