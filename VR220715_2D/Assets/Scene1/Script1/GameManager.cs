using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public Transform[] randEnemyType;
    public GameObject goEnemy;
    public GameObject goEnemy2;
    public float curEnemySpawnDelay;
    public float maxEnemySpawnTime;
    public GameObject goPlayer;
    public Image[] imglifes;
    public Text goScoretext;
    public GameObject goGameOver;
    public ObjectManager objmanager;
    public List<spawn> spawnList;
    public class spawn
    {
        public float delay;//나타나는시간
        public string tpye;//적기타입
        public int point;//스폰포인트 
    };

    // Start is called before the first frame update
    void Start()
    {
        goGameOver.SetActive(false);
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
        int randEnemyType = Random.Range(0, 2);
        // GameObject createEnemy = Instantiate(goEnemy, spawnPoints[randEnemyType].position, spawnPoints[randEnemyType].rotation);
        GameObject createEnemy = objmanager.MakeObject("Enemy");
        createEnemy.transform.position = spawnPoints[randPoint].position;

        Rigidbody2D rd = createEnemy.GetComponent<Rigidbody2D>();
        Enemy1 enemy = createEnemy.GetComponent<Enemy1>();
        

        rd.velocity = new Vector2(0, enemy.speed * (-1));
            
        curEnemySpawnDelay = 0;
        maxEnemySpawnTime = Random.Range(3f, 5f);
       
        enemy.objmanager = objmanager;
        enemy.goPlayer = goPlayer; //어차피 여기서 생성되므로 생성되면서 goPlayer 정보를 가져간다.

        
    }

    public void RespawnPlayer()
    {
        Invoke("AlivePlayer", 2.0f);
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
    
    public void GameOver()
    {
        goGameOver.SetActive(true);
    }
    public void startgame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

}

