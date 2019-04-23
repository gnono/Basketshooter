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

        //hitCounter++;
        foreach (Collider c in hitColliders) 
        {
          
            Rigidbody r = c.GetComponent<Rigidbody>();
            r.AddExplosionForce(explosionForce, transform.position, explosionRadius, upModifier);
            //Debug.Log("Explosion done: " + hitCounter);
                  
        }

        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<AudioSource>().Play();

        Kill();
        //Invoke("kill", 3f);
        explosion =Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        hitCounter++;

        if (collision.gameObject)
        {

            Debug.Log("Contact made: " + hitCounter);
        }
    }

    void Kill()
    {

        Destroy(gameObject);
        Destroy(explosion);
    }

}
