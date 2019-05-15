using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] Text GameOver;
    public GameObject FirstBall;

    public GameObject Paddle;
    private float currentTime = 0f;

    private float startingTime = 180f;


    [SerializeField] Text countdownText;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        //currentTime -= 1 * Time.deltaTime;
        //if (countdownText != null)
        //{
        //    countdownText.text = currentTime.ToString("00:00");
        //}

        float PlayTime = startingTime - Time.time;
        string minutes = ((int)PlayTime / 60).ToString();
        string seconds = (PlayTime % 60).ToString("f2");
        countdownText.text = minutes + ":" + seconds;


        if ((GameOver != null) && (currentTime <= 0))
        {
            currentTime = 0;
            GameOver.gameObject.SetActive(true);
            FirstBall.SetActive(false);

            Paddle.SetActive(false);


        }

    }

   
}
