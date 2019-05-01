using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


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
        NewBestTime.text = "Record: " +PlayerPrefs.GetFloat("NewBestTime", 0).ToString("F1" ) + "s";



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


        }

      
    }


    void Update()
    {
        float PlayTime = Time.time - currentTime;
        
        if (countdownText != null && !finished)
        {

            countdownText.text = (PlayTime).ToString("F1") + "s";


        }

        if (finished == false)
        {

        }

        else
        {

            if (PlayTime < PlayerPrefs.GetFloat("NewBestTime", float.MaxValue))
            {

                PlayerPrefs.SetFloat("NewBestTime", PlayTime);
                NewBestTime.text = "Record: " + PlayTime.ToString("F1") + "s";

                Debug.Log("Your time: " + PlayTime);
                PlayerPrefs.Save();
                Debug.Log("Eureka!" + NewBestTime);

            }

        }
    }


}
