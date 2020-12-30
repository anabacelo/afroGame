using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menuToSelect : MonoBehaviour
{
    public void PlayGame(int indice){
        SceneManager.LoadScene(indice);
    }

    public void exitGame(){
        Application.Quit();
    }
    
}
