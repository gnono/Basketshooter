using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarrierLogic : MonoBehaviour
{
    public GameObject bomb;
    public GameObject Message1;

    private void Start()
    {
        bomb.SetActive(true);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Barrier1"))
        {
            Debug.Log("Contact made with the 1st Barrier");
            bomb.SetActive(false);
            Message1.SetActive(true);
            StartCoroutine(wait(5F));
            Debug.Log("Show msg for 5s");



        }

        //if (other.CompareTag("Barrier2"))
        //{
        //    Debug.Log("Contact made with the 2nd Barrier");
        //    bomb.SetActive(true);
        //}

        //if (other.CompareTag("Barrier3"))
        //{
        //    Debug.Log("Contact made with the 3rd Barrier");
        //    bomb.SetActive(false);
        //}


    }


    private IEnumerator wait(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            //Debug.Log("Delay ends");
            Message1.SetActive(false);
        }
    }


}
