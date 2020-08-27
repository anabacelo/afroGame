using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anime;
    private Rigidbody rigid;
    private float horizontal;
    private float vertical;
    public float speed= 10f;


    void Start()
    {
        anime = GetComponentInParent<Animator>();
        rigid = GetComponentInParent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
    }

    void FixedUpdate() {
        //Horizontal
        if (Input.GetAxis("Horizontal") == 0)
        {
            anime.SetBool("isSideWalking", false);
        }
        else if (Input.GetAxis("Horizontal") < 0) {
            anime.SetBool("isSideWalking", true);
            transform.localScale = new Vector3(1, 1, 1);
            rigid.velocity = new Vector3(horizontal * speed,rigid.velocity.y, vertical*speed);
        }

        else if (Input.GetAxis("Horizontal") > 0)
        {
            anime.SetBool("isSideWalking", true);
            transform.localScale = new Vector3(-1, 1, 1);
            rigid.velocity = new Vector3(horizontal * speed, rigid.velocity.y, vertical * speed);
        }


        //Vertical

        if (Input.GetAxis("Vertical") == 0)
        {
            anime.SetBool("isFrontWalking", false);
            anime.SetBool("isBackWalking", false);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            anime.SetBool("isFrontWalking", true);
            rigid.velocity = new Vector3(horizontal * speed, rigid.velocity.y, vertical * speed);
            anime.SetBool("isBackWalking", false);
        }

        else if (Input.GetAxis("Vertical") > 0)
        {
            anime.SetBool("isBackWalking", true);            
            rigid.velocity = new Vector3(horizontal * speed, rigid.velocity.y, vertical * speed);
            anime.SetBool("isFrontWalking", false);
        }






    }
}
