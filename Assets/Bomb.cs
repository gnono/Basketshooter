using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public float delay;
    public GameObject Target;
    public int hitCounter;
    public float explosionForce;
    public float explosionRadius;
    public float upModifier;
    public LayerMask interactionMask;
    public GameObject explosionEffectPrefab;
    public GameObject explosion;





    // Start is called before the first frame update
    void Start()
    {
        Invoke("explode",delay);
       
    }

    // Update is called once per frame
    void explode()
    {
        Collider [] hitColliders =Physics.OverlapSphere(transform.position, explosionRadius, interactionMask);

       
        foreach (Collider c in hitColliders) 
        {
          
            Rigidbody r = c.GetComponent<Rigidbody>();
            r.AddExplosionForce(explosionForce, transform.position, explosionRadius, upModifier);
         

        }



        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<AudioSource>().Play();

        explosion = Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);


    }

  

}
