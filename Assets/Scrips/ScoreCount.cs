using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreCount : MonoBehaviour
{
    public static int scoreValue = 0;
    Text score;
    private int nextTarget = 30;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "SCORE: " + scoreValue;
    }
    void LateUpdate()
    {
        if (scoreValue == nextTarget && EnemyController.timeFire > 1f && SpawnEnemy.minRan > 1f)
        {
            PlayerControler.speed += 0.5f;
            EnemyController.timeFire -= 0.25f;
            SpawnEnemy.minRan -= 0.25f;
            SpawnEnemy.maxRan -= 0.25f;
            nextTarget += 30;
        }
    }
}
