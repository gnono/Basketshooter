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

   // public GameObject level1;
   // public GameObject level2;
   public GameObject level3;


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

       // level1.SetActive(true);
       // level2.SetActive(false);
       level3.SetActive(false);

        //NewBestTime.text = "Record: " + PlayerPrefs.GetFloat("NewBestTime", 0).ToString("F1") + "s";
        if (YouWonMessage != null)
        {
            YouWonMessage.gameObject.SetActive(false);
        }
    }


    

  /**  private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("Boss killed");
            YouWonMessage.gameObject.SetActive(true);
            finished = true;
        }
    }
    */
    void OnCollisionEnter(Collision collision)
    {


        if (collision.transform.tag == "Bullet")
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


        if(currentTime == 40)
        {
           // level2.SetActive(true);
        }

        else if(currentTime == 90)
        {
        level3.SetActive(true);
        
    }
       


    }


        






}
