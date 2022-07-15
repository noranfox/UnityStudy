using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject goEnemy;
    public float curEnemySpawnDelay;
    public float maxEnemySpawnTime;
    public GameObject goPlayer;
    public Image[] imglifes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
        ReloadEnemy();  
    }

    void ReloadEnemy()
    {
        curEnemySpawnDelay += Time.deltaTime;
    }

    void SpawnEnemy()
    {
        if (curEnemySpawnDelay < maxEnemySpawnTime)
        {
            return;
        }
        int randPoint = Random.Range(0, 3);
        GameObject createEnemy = Instantiate(goEnemy, spawnPoints[randPoint].position, spawnPoints[randPoint].rotation);

        Rigidbody2D rd = createEnemy.GetComponent<Rigidbody2D>();
        Enemy1 enemy = createEnemy.GetComponent<Enemy1>();

        rd.velocity = new Vector2(0, enemy.speed * (-1));
            
        curEnemySpawnDelay = 0;
        maxEnemySpawnTime = Random.Range(3f, 5f);

        enemy.goPlayer = goPlayer; //어차피 여기서 생성되므로 생성되면서 goPlayer 정보를 가져간다.
        
    }

    public void RespawnPlayer()
    {
        Invoke("AlivePlayer", 2.0f);
    }

    void GameOver()
    {
        
        
    }
    void AlivePlayer()
    {
        goPlayer.transform.position = Vector2.down * 3.5f;
        goPlayer.SetActive(true);
        Player1 PlayerLogic = goPlayer.GetComponent<Player1>();
        PlayerLogic.isHit = false;
    }
    public void UpdateLifeIcon(int life)
    {
        for(int idx =0; idx <3; idx ++)
        {
            imglifes[idx].color = new Color(1, 1, 1, 0);
        }
        for(int idx =0; idx < life; idx++)
        {
            imglifes[idx].color = new Color(1, 1, 1, 1);
        }


    }
}

