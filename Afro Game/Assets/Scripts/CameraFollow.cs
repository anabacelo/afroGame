using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    private Transform targetToFollow;
    
    //quanto maior, mais suave a camera vai seguir (valores de 0 a 1)
    public float smoothSpeed = 0.125f;

    //para movimentar a camera
    public Vector3 offset;

    private void Start() {
        GameObject playerToFollow = target.transform.GetChild(PlayerPrefs.GetInt("characterSelected")).gameObject; 
        targetToFollow = playerToFollow.GetComponent<Transform>();
    }
    private void FixedUpdate() {
        Vector3 desiredPosition = targetToFollow.position + offset;
        
        //Lerp = Linear Interpolation começa do ponto A e termina no B usando uma velocidade X
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(targetToFollow);
    }

    public void SetOffset(string offsetWSpace){
        string[] xyz = offsetWSpace.Split(' ');
        Vector3 offsetDesired = new Vector3(float.Parse(xyz[0]),float.Parse(xyz[1]),float.Parse(xyz[2]));
        offset = offsetDesired;
    }
}
