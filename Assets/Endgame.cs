using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Endgame : MonoBehaviour
{
    public GameObject Message1;
    public GameObject bomb;
    public GameObject bullets;

    private float currentTime;
    private float startingTime;
    [SerializeField] Text countdownText;

    [SerializeField] Text NewBestTime;
    private bool finished = false;


    private void Start()
    {
        bomb.SetActive(true);
        bullets.SetActive(true);
        currentTime = Time.time;
        NewBestTime.text = PlayerPrefs.GetFloat("NewBestTime", 0).ToString("Record: "+"00:00");
        //Debug.Log("New Record of time" + NewBestTime);

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BarrierReward1"))
        {
            Debug.Log("Contact made with the Barrier Reward");

            Message1.SetActive(true);
            bomb.SetActive(false);
            bullets.SetActive(false);

            finished = true;
            //gamefinished = true;

        }

      
    }


    void Update()
    {
        float PlayTime = Time.time - currentTime;
        string minutes = ((int)PlayTime / 60).ToString("00");
        string seconds = (PlayTime % 59).ToString("f1");

        if(countdownText != null && !finished)
        {
            countdownText.text = minutes + ":" + seconds;
        }

        if(finished == false)
        {

        }

        else
        {
            GameFinished();
        }

    }

    void GameFinished()
    {

        float t = Time.time - currentTime;
        if (t < PlayerPrefs.GetFloat("NewBestTime", float.MaxValue))
        {
            PlayerPrefs.SetFloat("NewBestTime", t);
            NewBestTime.text = t.ToString("Record: " + "00:00");
            PlayerPrefs.Save();

            Debug.Log("Eureka!"+ NewBestTime);

        }


    }
}
