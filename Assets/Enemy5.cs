using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5 : MonoBehaviour
{
    public Transform player;
    static Animator anim;


    private bool deplacement;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        deplacement = true;

    }



    void Magnitude(bool deplacement)
    {
        if (deplacement)
        {
            Vector3 direction = player.position - this.transform.position;

            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            anim.SetBool("isIdle", false);
            if (direction.magnitude > 6)
            {
                this.transform.Translate(0, 0, 0.25f);
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);
            }
            else
            {
                anim.SetBool("isAttacking", true);
                anim.SetBool("isWalking", false);
            }



        }

        if (!deplacement)
        {
            this.transform.Translate(0, 0, 0f);
        }
    }
    // Update is called once per frame
    void Update()
    {


        if (Vector3.Distance(player.position, this.transform.position) < 40)
        {
            Magnitude(deplacement);
        }
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);
        }


    }

    void OnCollisionEnter(Collision collision)
    {


        if (collision.transform.tag == "Bullet")
        {
            Debug.Log("touchBull");
            anim.SetBool("isDeath", true);
            Destroy(this, 4);
            deplacement = false;
            Magnitude(deplacement);

            anim.SetBool("isIdle", false);
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);

        }

        if (collision.transform.tag == "FPS")
        {
            Debug.Log("touchFPS");




        }



    }


}
