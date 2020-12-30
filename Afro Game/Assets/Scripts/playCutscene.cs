using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class playCutscene : MonoBehaviour
{
    public PlayableDirector cutscene;
    public List<GameObject> objectsToDisable;
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            objectsToDisable.ForEach(item => item.SetActive(false));
            cutscene.Play();
        }
    }
}
