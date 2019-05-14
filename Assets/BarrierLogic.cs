using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarrierLogic : MonoBehaviour
{
    public Camera Camera1;
    public Camera Camera2;
    public Camera Camera3;
    public Camera Camera4;

    //public GameObject Barrier;


    private void Start()

    {
    
        StartCoroutine(wait(5F));
        Debug.Log("Countdown started");

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barrier1"))
        {

            Debug.Log("Object was hit");
            Camera1.enabled = true;
            StartCoroutine(wait(5F));
            Debug.Log("Deactivate Camera in 5s");

        }

        if (other.CompareTag("Barrier2"))
        {

            Debug.Log("Object was hit");
            Camera2.enabled = true;
            StartCoroutine(wait(5F));
            Debug.Log("Deactivate Camera in 5s");

        }



    }


    private IEnumerator wait(float delay)
    {
        while (true)
        {

            yield return new WaitForSeconds(delay);
            Debug.Log("Camera deactivated after 5s");
            Camera1.enabled = false;
            Camera2.enabled = false;
            StartCoroutine(wait(5F));

        }
    }




}
