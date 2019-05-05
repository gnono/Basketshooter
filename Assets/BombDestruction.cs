using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDestruction : MonoBehaviour
{

    private int hitCounter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ramp")
        {
            Destroy(collision.gameObject, 0.5F);
            Debug.Log("Ramp destroyed");
        }


    }
}
