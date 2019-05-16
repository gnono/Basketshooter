using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    AudioSource bulletAudio;
    public GameObject explosionEffectPrefab;
    private float hitCounter;
    
    // Use this for initialization
    void Start () {

        bulletAudio = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.tag == "Target")
        {
            hitCounter++;
            hitCounter += hitCounter;
            GameObject effect = Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.6F);
            Destroy(collision.gameObject);
           


            bulletAudio.Play();
            gameObject.SetActive(false);
            Debug.Log("Target destroyed");


        }

      


    }


}
