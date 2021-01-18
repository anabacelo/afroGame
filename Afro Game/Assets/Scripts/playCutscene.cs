using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class playCutscene : MonoBehaviour
{
    public PlayableDirector cutsceneGirl;
    public PlayableDirector cutsceneBoy;


    public List<GameObject> objectsToDisable;
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            objectsToDisable.ForEach(item => item.SetActive(false));
            if(PlayerPrefs.GetInt("characterSelected") == 0){
                cutsceneGirl.Play();
            } else cutsceneBoy.Play();
        }
    }

    public void play(){
        if(PlayerPrefs.GetInt("characterSelected") == 0){
            cutsceneGirl.Play();
        } else cutsceneBoy.Play();
    }
}
