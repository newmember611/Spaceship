﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefrab;
    private Vector3 bounds, scaleEnemy, coliderEnemy;
    public static float minRan = 3f, maxRan = 4f;
    

    // Start is called before the first frame update
    void Start()
    {
        
        
        bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        scaleEnemy = enemyPrefrab.GetComponent<Transform>().localScale;

        coliderEnemy = enemyPrefrab.GetComponent<BoxCollider2D>().size;

        StartCoroutine(Spawn());
    }

    
    IEnumerator Spawn()
    {
        Vector3 temp = transform.position;

        
        
        temp.x += Random.Range((-bounds.x + (coliderEnemy.x / 2 * scaleEnemy.x)), (bounds.x - (coliderEnemy.x / 2 * scaleEnemy.x)));

        GameObject enemy = (GameObject)Instantiate(enemyPrefrab, temp, Quaternion.identity);
        Destroy(enemy, 7);



        //wait for some time
        yield return new WaitForSeconds(Random.Range(minRan,maxRan));


        StartCoroutine(Spawn());

    }

}