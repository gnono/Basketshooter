using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;



public class Timer : MonoBehaviour
{
    [SerializeField] Text GameOver;
    private float currentTime;
    private float startingTime = 160f;


    [SerializeField] Text countdownText;
    [SerializeField] Text YouWonMessage;
    private bool finished = false;
    [SerializeField] Text NewBestTime;

    public GameObject Bullet;

    void Start()
    {
        currentTime = Time.time;
        GameOver.gameObject.SetActive(false);
        Bullet.SetActive(true);


        //NewBestTime.text = "Record: " + PlayerPrefs.GetFloat("NewBestTime", 0).ToString("F1") + "s";
        if (YouWonMessage != null)
        {
            YouWonMessage.gameObject.SetActive(false);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Reward")
        {
            Debug.Log("Boss killed");
            YouWonMessage.gameObject.SetActive(true);
            finished = true;

        }
    }


    void Update()
    {

         float PlayTime = startingTime - Time.time;

        if (countdownText != null && !finished)
        {

            countdownText.text = (PlayTime).ToString("F1") + "s";


        }

        if (finished == false)
        {

        }

        //else
        //{

        //    if (PlayTime > PlayerPrefs.GetFloat("NewBestTime", float.MaxValue))
        //    {

        //        PlayerPrefs.SetFloat("NewBestTime", currentTime);
        //        NewBestTime.text = "Record: " + currentTime.ToString("F1") + "s";

        //        Debug.Log("Your time: " + currentTime);
        //        PlayerPrefs.Save();
        //        Debug.Log("Eureka!" + NewBestTime);

        //    }

        //}


    }


        







private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Well"))
        {

        }
    }

}
