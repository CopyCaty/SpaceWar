using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class LogicScript : MonoBehaviour
{
    public int score = 0;
    public float time = 0;
    public Text scoreText;
    public Text timeText;
    public void gameStart()
    {
        SceneManager.LoadScene("GameScenes");
    }

    public void gameQuit()
    {
        Application.Quit();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if(SceneManager.GetActiveScene().name == "GameScenes")
        {
            timeUpdate();
        }
    }

    public void scoreUpdate(int val)
    {
        score += val;
        scoreText.text = "Score: " + score;
    }
    public void timeUpdate()
    {
        time += Time.deltaTime;
        timeText.text = "Time: " + Mathf.Floor(time);
    }
}
