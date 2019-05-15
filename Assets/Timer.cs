using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;



public class Timer : MonoBehaviour
{
    [SerializeField] Text GameOver;
    private float currentTime = 0f;
    private float startingTime = 200f;
    private float PlayTime;

    [SerializeField] Text countdownText;
    [SerializeField] Text YouWonMessage;
    private bool finished = false;
    [SerializeField] Text NewBestTime;


    void Start()
    {
        StartCoroutine("LoseTime");
        Time.timeScale = 1;
        GameOver.gameObject.SetActive(false);
        NewBestTime.text = "Record: " + PlayerPrefs.GetFloat("NewBestTime", 0).ToString("F1") + "s";
        if (YouWonMessage != null)
        {
            YouWonMessage.gameObject.SetActive(false);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "BossKill")
        {
            Debug.Log("Boss killed");
            YouWonMessage.gameObject.SetActive(true);
            finished = true;

        }
    }


    void Update()
    {

        startingTime -= 1 * Time.deltaTime;
        PlayTime = Time.time;
        if (countdownText != null && !finished)
        {

            //countdownText.text = (startingTime).ToString("F1") + "s";
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


        if ((GameOver != null) && (PlayTime >= 300))
        {
            PlayTime = 300;

            GameOver.gameObject.SetActive(true);
            countdownText.text = PlayTime.ToString("00.0") + "s";

        }

    }


    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            startingTime--;
        }
    }








private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Well"))
        {

        }
    }

}
