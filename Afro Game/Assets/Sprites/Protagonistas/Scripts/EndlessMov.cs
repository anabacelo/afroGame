using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessMov : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){

        }
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
            
        }

    }

    private void FixedUpdate() {
        rb.velocity = Vector3.forward * speed;
    }
}
