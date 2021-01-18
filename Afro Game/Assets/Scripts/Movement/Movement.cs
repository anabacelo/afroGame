using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    public float speed= 10f;
    public Rigidbody rigid;
    public BoxCollider target;
    public BoxCollider here;

    private void Start() {
        GameObject objectTarget = transform.GetChild(PlayerPrefs.GetInt("characterSelected")).gameObject; 
        target = objectTarget.GetComponent<BoxCollider>();
    }
    private void Update() {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }
    void FixedUpdate()
    {
        //to move with the player
        //here.transform =

        //Horizontal
        if (Input.GetAxis("Horizontal") < 0) {
            transform.localScale = new Vector3(1, 1, 1);
            rigid.velocity = new Vector3(horizontal * speed,rigid.velocity.y, vertical*speed);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            rigid.velocity = new Vector3(horizontal * speed, rigid.velocity.y, vertical * speed);
        }

        //Vertical
        if (Input.GetAxis("Vertical") < 0)
        {
            rigid.velocity = new Vector3(horizontal * speed, rigid.velocity.y, vertical * speed);
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            rigid.velocity = new Vector3(horizontal * speed, rigid.velocity.y, vertical * speed);
        }
    }
}
