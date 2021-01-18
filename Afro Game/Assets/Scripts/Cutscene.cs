using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public void desactivateAnimation(string state){
        int playerIndex = PlayerPrefs.GetInt("characterSelected");
        GameObject player = transform.GetChild(playerIndex).gameObject;
        Animator anim = player.gameObject.GetComponent<Animator>();
        anim.SetBool(state, false);
        
    }

    public void activeAnimation(string state){
        int playerIndex = PlayerPrefs.GetInt("characterSelected");
        GameObject player = transform.GetChild(playerIndex).gameObject;
        Animator anim = player.gameObject.GetComponent<Animator>();
        anim.SetBool(state, true);
    }

    public void changeTo(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    
}
