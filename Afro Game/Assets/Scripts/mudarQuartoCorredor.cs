using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mudarQuartoCorredor : MonoBehaviour
{
    public MeshRenderer textura1;
    public MeshRenderer textura2;
    public MeshRenderer textura3;
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            textura1.enabled = textura1.enabled ? false : true;
            textura2.enabled = textura2.enabled ? false : true;
            textura3.enabled = textura3.enabled ? false : true;
        }
    }
}
