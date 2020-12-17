using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTime : MonoBehaviour
{
    public static float currentTime;
    float startingTime;
    Text timeText;
    private GamePlayController GamePlay;

    // Start is called before the first frame update
    void Start()
    {
        GamePlay = GameObject.Find("Game Play Controller").GetComponent<GamePlayController>();

        if (SceneManager.GetActiveScene().name == "Easy_Mode")
            startingTime = 30f;
        else if (SceneManager.GetActiveScene().name == "Medium_Mode")
            startingTime = 40f;
        else if (SceneManager.GetActiveScene().name == "Hard_Mode")
            startingTime = 50f;

        timeText = GetComponent<Text>();

        currentTime = startingTime;

    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        timeText.text = "TIME TO LIVE: " + currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            GamePlay.PlayerDieShowPanel();
            
        }
    }
}
