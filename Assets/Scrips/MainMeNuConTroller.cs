using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMeNuConTroller : MonoBehaviour
{
    public void StartGame_EasyMode()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Application.LoadLevel("Easy_Mode");
    }
    public void StartGame_MediumMode()
    {
        Application.LoadLevel("Medium_Mode");
    }
    public void StartGame_HardMode()
    {
        Application.LoadLevel("Hard_Mode");
    }
    public void QuitGame()
    {
        Debug.Log("Bạn Đã Thoát Game");
        Application.Quit();
    }
    public void  Tutorial()
    {
        Application.LoadLevel("Tutorial");
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
