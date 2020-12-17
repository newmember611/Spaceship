using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    private GamePlayController GamePlay;
    private Rigidbody2D rigidBody;
    [SerializeField]
    private GameObject bulletPrefab;
    public float speed, speedBullet;
    public static float timeFire = 3f;
    public static int health;
    void Start()
    {
        GamePlay = GameObject.Find("Game Play Controller").GetComponent<GamePlayController>();
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(Fire());

        if (SceneManager.GetActiveScene().name == "Easy_Mode")
            health = 1;
        else if (SceneManager.GetActiveScene().name == "Medium_Mode")
            health = 2;
        else if (SceneManager.GetActiveScene().name == "Hard_Mode")
            health = 3;
    }
    void FixedUpdate()
    {
        EnemyMove();
    }
    void EnemyMove()
    {
        rigidBody.velocity = Vector2.down * speed;
    }
    IEnumerator Fire()
    {
        Vector3 temp = transform.position;
        temp.y -= 0.3f;
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, temp, Quaternion.identity);
        bullet.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.down * speedBullet;
        Destroy(bullet, 3);
        yield return new WaitForSeconds(timeFire);
        StartCoroutine(Fire());
    }
}
