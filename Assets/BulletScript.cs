using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    AudioSource bulletAudio;
    public GameObject explosionEffectPrefab;
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
            Destroy(collision.gameObject);
            GameObject effect = Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 1F);

            bulletAudio.Play();
            gameObject.SetActive(false);
            Debug.Log("Target destroyed");
        }
    }


}
