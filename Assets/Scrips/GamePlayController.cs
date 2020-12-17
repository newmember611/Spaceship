using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;
    [SerializeField]

    private GameObject pausePanel, gameOverPanel, Player;
    //public bool instance;
    void Ake()
    {
        makeinstance();
    }
    void makeinstance()
    {
        if (instance == null)
            instance = this;
    }

    public void PauseGameButton() /*btn dừng game */
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeGameButton() /*btn tiếp tục game khi dừng */
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void RestartButton() /*btn chơi lại */
    {
        gameOverPanel.SetActive(false);
        if (Player == null)
        {
            Player = this.Player;
        }
        Time.timeScale = 1f;
        ScoreCount.scoreValue = 0;
        PlayerControler.speed = 5f;
        EnemyController.timeFire = 3f;
        SpawnEnemy.minRan = 3f;
        SpawnEnemy.maxRan = 4f;
        
        Application.LoadLevel(SceneManager.GetActiveScene().name);
        
    }
    public void OptionsButton() /*btn quay về main menu */
    {
        Application.LoadLevel("MainMenu");
    }

    /*Hiển thị Panel game over khi va chạm player và enemy*/
    public void PlayerDieShowPanel()
    {
        gameOverPanel.SetActive(true);
    }
}
