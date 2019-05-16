using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject cubePrefab;
    public GameObject pickUpObject;
    private int hitCounter;    
    public GameObject rampPrefab;
    public Transform hand;  
    public Camera cam;
    public float maxDist;
    public float throwforce;
    private float throwforceRamp = 2000;
    public LayerMask interactionLayer;
    private Rigidbody objInHand;
    public GameObject ballPrefab;
    public GameObject bullet;
    private float bulletSpeed = 3000;

    public Material opaqueMat;
    public Material transparentMat;
    private bool transparent;
    private GameObject ramp;
    public Transform objectPosition;


    [SerializeField] Text Basketthrows;

    // Start is called before the first frame update
    void Start()
    {
       // bombPrefab.SetActive(true);
        Basketthrows.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
      //  if (other.gameObject.tag == "wall1")
       // {
       //     InvokeRepeating("EnemySpawner", 0.5f, repeatRate);
         //   Destroy(gameObject, 11);
        //    gameObject.GetComponent<BoxCollider>().enabled = false;
      //  }
    }
   // void EnemySpawner()
   // {
       // Instantiate(enemy, enemyPosition.position, enemyPosition.rotation);
   // }

    // Change Material
    void UpdateMaterial(bool transparent)
    {

        if (transparent)
        {
            ramp.GetComponent<Renderer>().material = transparentMat;
        }
        if ((ramp != null) && !transparent)
        {
            ramp.GetComponent<Renderer>().material = opaqueMat;
        }
    }


    // Update is called once per frame
    void Update()
    {

        //ramp
        if (Input.GetKeyDown(KeyCode.R))
        {


            if (objInHand == null)
            {
                ramp = Instantiate(rampPrefab, objectPosition.position, Quaternion.identity);
                transparent = true;
                UpdateMaterial(transparent);
                objInHand = ramp.transform.GetComponent<Rigidbody>();

                objInHand.transform.parent = objectPosition;
                objInHand.isKinematic = true;
                ramp.transform.localEulerAngles = Vector3.zero;
                transparent = false;

            }

        }



        if (Input.GetKeyDown(KeyCode.T))
        {
            if (Time.timeScale ==1F)
            {

                Time.timeScale = 0.25F;

            }

            else { Time.timeScale = 1F; }
        }


        if (Input.GetKey(KeyCode.Mouse1))
        {

            Ray ray = new Ray(cam.transform.position, cam.transform.forward);
            Debug.DrawLine(ray.origin, ray.GetPoint(maxDist));


            if (objInHand == null)
            {

                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, maxDist, interactionLayer))
                {

                    objInHand = hit.transform.GetComponent<Rigidbody>();
                    objInHand.transform.position = hand.position;
                    objInHand.transform.parent = hand;
                    objInHand.isKinematic = true;
                    pickUpObject.SetActive(true);

                }
            }

        }

        if (Input.GetKeyDown(KeyCode.B))
        {

            pickUpObject.SetActive(false);

            if (objInHand != null)
            {

                objInHand.transform.parent = null;
                objInHand.isKinematic = false;
                objInHand.AddForce(cam.transform.forward * throwforce);
                objInHand = null;
            }

            else
            {

                GameObject bomb = Instantiate(ballPrefab, hand.position, Quaternion.identity);
                bomb.GetComponent<Rigidbody>().AddForce(cam.transform.forward * throwforce);
                hitCounter++;
                Debug.Log("Number of balls thrown: " + hitCounter);

                if (hitCounter == 1)
                {

                    Basketthrows.text = "2/3";
                }
                else if (hitCounter == 2)
                {
                    Basketthrows.text = "1/3";
                }

                else if(hitCounter == 3)
                {
                    Basketthrows.text = "0/3";

                }
                else if (hitCounter >= 4)
                {
                    Basketthrows.text = "0/3";
                  //  bombPrefab.SetActive(false);
                    Basketthrows.gameObject.SetActive(false);
                    Destroy(bomb);
                    Debug.Log("Bombs deactivated: " + hitCounter);
                }


                DestroyTarget();
               

            }


        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            pickUpObject.SetActive(false);

            if (objInHand != null)
            {
                UpdateMaterial(transparent);
                objInHand.transform.parent = null;
                objInHand.isKinematic = false;
                objInHand.AddForce(cam.transform.forward * throwforce);
                objInHand = null;
            }

            else
            {
                Debug.Log("Bullet shot");
                GameObject bulletPrefab = Instantiate(bullet, hand.position, Quaternion.identity);

                bulletPrefab.transform.parent = hand.parent;
                bulletPrefab.transform.localEulerAngles = Vector3.zero;
                bulletPrefab.transform.parent = null;
                bulletPrefab.GetComponent<Rigidbody>().AddForce(cam.transform.forward * bulletSpeed);
                Destroy(bulletPrefab, 0.5f);

            }

        }


        void DestroyTarget()
        {

            GameObject[] targets = GameObject.FindGameObjectsWithTag("Ramp");

        }


    }
}
