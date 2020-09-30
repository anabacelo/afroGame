using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessMov : MonoBehaviour
{
    public float speed = 10f;
    public float lineSpeed = 10f;
    public Rigidbody rb;
    private float currentLine = 0f;
    Vector3 verticalTargetPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
        verticalTargetPosition  = new Vector3(transform.position.x, 2, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
            changeLine(-2f);
        }
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
            changeLine(2f);
            
        }

        Vector3 targetPosition = new Vector3(verticalTargetPosition.x, verticalTargetPosition.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, lineSpeed * Time.deltaTime);
    }

    private void FixedUpdate() {
        rb.velocity = Vector3.forward * speed;
    }


    void changeLine(float direction){
        float targetLine = currentLine + direction;
        if(targetLine < -2f || targetLine > 2f){
            return;
        }
        currentLine = targetLine;
        verticalTargetPosition = new Vector3((currentLine), transform.position.y, 0);
    }
}
