using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GamePlayController GamePlay;
    private void Start()
    {
        GamePlay = GameObject.Find("Game Play Controller").GetComponent<GamePlayController>();
    }
    void OnTriggerEnter2D(UnityEngine.Collider2D Other)
    {
       if (Other.CompareTag("Player"))
            {
                Destroy(gameObject);
                Destroy(Other.gameObject);
                GamePlay.PlayerDieShowPanel();
                Time.timeScale = 1f;
            }
    }
    
}
