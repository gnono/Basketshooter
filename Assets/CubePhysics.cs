using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePhysics : MonoBehaviour
{
    private Vector3 velocity;

 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Cube(Clone)")
        {
            //velocity = new Vector3(-velocity.x, -velocity.y, -velocity.z);
            Debug.Log("Ground touched");
        }
    }
}
