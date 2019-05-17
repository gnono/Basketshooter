using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    
    [SerializeField] Text goal;
  
    // Start is called before the first frame update
    void Start()
    {
        goal.gameObject.SetActive(false);
        StartCoroutine(wait(5F));

    }

    // Update is called once per frame
    void Update()
    {

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            Debug.Log("goal");
            PlayerHealth.ph.TakeDamage(-100);
            Debug.Log("++");
            goal.gameObject.SetActive(true);
            StartCoroutine(wait(5));
            
        }
    }

    private IEnumerator wait(float delay)
    {
        while (true)
        {



            yield return new WaitForSeconds(delay);
            Debug.Log("Camera deactivated after 5s");
            goal.gameObject.SetActive(false);
            
            StartCoroutine(wait(5F));

        }
    }
}
