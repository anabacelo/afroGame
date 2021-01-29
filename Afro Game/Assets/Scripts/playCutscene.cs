using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class playCutscene : MonoBehaviour
{
    public PlayableDirector cutsceneGirl;
    public PlayableDirector cutsceneBoy;

    public List<GameObject> objectsToDisable;
    public List<GameObject> objectsToEnable;
    public List<GameObject> objectsToEnableGirl;
    public List<GameObject> objectsToEnableBoy;


    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            objectsToDisable.ForEach(item => item.SetActive(false));
            objectsToEnable.ForEach(item => item.SetActive(true));
            if(PlayerPrefs.GetInt("characterSelected") == 0){
                cutsceneGirl.Play();
                objectsToEnableGirl.ForEach(item => item.SetActive(true));
            } else{
                cutsceneBoy.Play();
                objectsToEnableBoy.ForEach(item => item.SetActive(true));
            } 
        }
    }

    public void play(){
        if(PlayerPrefs.GetInt("characterSelected") == 0){
            cutsceneGirl.Play();
        } else cutsceneBoy.Play();
    }
}
