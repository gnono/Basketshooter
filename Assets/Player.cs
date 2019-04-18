using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject cubePrefab;
    public Transform hand;
    public Camera cam;
    public float maxDist;
    public float throwforce;
    public LayerMask interactionLayer;
    private Rigidbody objInHand;
    public GameObject bombPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) 
        {
           GameObject cube = Instantiate(cubePrefab, hand.position, Quaternion.identity);
            cube.GetComponent<Rigidbody>().AddForce(cam.transform.forward*throwforce);
            }


        if (Input.GetKeyDown(KeyCode.T))
        {
            if(Time.timeScale == 1) 
            { 
            
            Time.timeScale = 0.25F; 
            
            }

            else { Time.timeScale = 1; }
        }


        if (Input.GetKey(KeyCode.Mouse1)) 
        {

            Ray ray = new Ray(cam.transform.position, cam.transform.forward);
            Debug.DrawLine(ray.origin, ray.GetPoint(maxDist));


            if(objInHand == null) {

                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, maxDist, interactionLayer))
                {

                    objInHand = hit.transform.GetComponent<Rigidbody>();
                    objInHand.transform.position = hand.position;
                    objInHand.transform.parent = hand;
                    objInHand.isKinematic = true;

                }
            }

        }

        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {

            if(objInHand != null) 
            {

                objInHand.transform.parent = null;
                objInHand.isKinematic = false;
                objInHand.AddForce(cam.transform.forward * throwforce);
                objInHand = null;
            }

            else
            {

                GameObject bomb = Instantiate(bombPrefab, hand.position, Quaternion.identity);
                bomb.GetComponent<Rigidbody>().AddForce(cam.transform.forward * throwforce);
            }

        }
    }
}
