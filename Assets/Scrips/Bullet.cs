using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    public GameObject explosion;
    int time;
    void OnTriggerEnter2D(Collider2D Other)
    {

        if (Other.CompareTag("Enemy") )
        {
            Destroy(gameObject);
            EnemyController.health -= 1;
            if (EnemyController.health <= 0)
            {
                //Cộng điểm khi hạ gục enemy
                ScoreCount.scoreValue += 10;

                //Cộng thời gian khi hạ gục enemy
                if (SceneManager.GetActiveScene().name == "Easy_Mode")
                    time = 5;
                else if (SceneManager.GetActiveScene().name == "Medium_Mode")
                    time = 10;
                else if (SceneManager.GetActiveScene().name == "Hard_Mode")
                    time = 20;
                CountdownTime.currentTime += time;


                //Hủy đối tượng enemy khi bị tiêu diệt
                Destroy(Other.gameObject);

                //Khởi tạo animation vụ nổ
                Instantiate(explosion, Other.transform.position, Other.transform.rotation);

                //Khởi tạo lại máu cho enemy
                if (SceneManager.GetActiveScene().name == "Easy_Mode")
                    EnemyController.health = 1;
                else if (SceneManager.GetActiveScene().name == "Medium_Mode")
                    EnemyController.health = 2;
                else if (SceneManager.GetActiveScene().name == "Hard_Mode")
                    EnemyController.health = 3;
            }
            
        }
        

    }
}
