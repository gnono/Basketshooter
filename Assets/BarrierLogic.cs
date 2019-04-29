using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarrierLogic : MonoBehaviour
{
    public GameObject bomb;
    public GameObject Message1;
    public GameObject Message2;
    public GameObject Message3;

    public GameObject Barrier;
    private float hitCounter;
    private float hitCounter2;
    private float hitCounter3;

    private void Start()
    {
        bomb.SetActive(true);


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Barrier1"))
        {
            hitCounter++;
            Debug.Log("Counter started");
            if(hitCounter == 1)
            {
                Debug.Log("Contact made with the 1st Barrier: " + hitCounter);
                bomb.SetActive(false);
                Message1.SetActive(true);
                StartCoroutine(wait(5F));
                Debug.Log("Show msg for 5s");
            }



        }


        if (other.CompareTag("Barrier2"))
        {
            hitCounter2++;
            Debug.Log("Counter started at barrier 3: " + hitCounter2);
            if (hitCounter2 == 1)
            {
                Debug.Log("Contact made with the 3rd Barrier");
                bomb.SetActive(true);
                Message2.SetActive(true);
                StartCoroutine(wait(5F));
                Debug.Log("Show msg for 5s");
            }
        }

        if (other.CompareTag("Barrier3"))
        {
            hitCounter3++;
            Debug.Log("Counter started at barrier 3: " + hitCounter3);
            if (hitCounter3 == 2)
            {
                Debug.Log("Contact made with the 3rd Barrier");
                bomb.SetActive(true);
                Message3.SetActive(true);
                StartCoroutine(wait(5F));
                Debug.Log("Show msg for 5s");
            }
        }




    }


    private IEnumerator wait(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            //Debug.Log("Delay ends");
            Message1.SetActive(false);
            Message2.SetActive(false);
            Message3.SetActive(false);
            StartCoroutine(wait(5F));

        }
    }


}
