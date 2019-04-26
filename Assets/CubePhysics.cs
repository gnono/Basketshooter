using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePhysics : MonoBehaviour
{
    private int hitCounter;
    public GameObject bomb;

 //void countUp() 

 //{
 
    //    if (bomb.gameObject.GetComponent<Rigidbody>())
    //    {
    //        hitCounter++;
    //        Debug.Log("Hit by a bomb" + hitCounter);
    //    }
    //    else
    //    {
    //        Debug.Log("Not hit by a bomb");
    //    }

    //}


   
    void onCollisionEnter()

    {
        var hit = bomb.GetComponent<SphereCollider>();
        hitCounter++;

        if (hit == true)
        {
            Debug.Log("Hit by a bomb" + hitCounter);
        }

        else
        {
            Debug.Log("Not hit by a bomb");
        }

    }

}
