using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TG_Coin : MonoBehaviour
{
    public float rs = 200.0f;
    Rigidbody Coin;
  //  AudioSource caudio;
    // Start is called before the first frame update
    void Start()
    {
        Coin = GetComponent<Rigidbody>();
       // caudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up *rs * Time.deltaTime, Space.World);
    }

   /* private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            
            TG_playerBall player = other.GetComponent<TG_playerBall>();
            player.itemCount++;
            caudio.Play();
            gameObject.SetActive(false);
        }

     �Ҹ� �۵����ѵ� �ٷ� ��Ȱ��ȭ�Ǳ⶧���� player���� �ϴ°Ը´�
    */

}
