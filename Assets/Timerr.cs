using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timerr : MonoBehaviour
{
    public GameObject GameOver;
    public float timeValue = 30;
    public Text timeText;
    bool finish = false;
    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
            DisplayTime(timeValue);
        }
        else if(!finish)
        {
            finish = true;
            timeValue = 0;
            KeyHolder.Instance.showScore();
            Debug.Log("Game Over");
            GameOver.SetActive(true);
            QuitGame();
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
