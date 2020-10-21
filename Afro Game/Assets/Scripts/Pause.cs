using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI;
public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;

    public void returnToMenu(){
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void pause(){
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void resume(){
        Time.timeScale = 1;
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.P)){
            pause();
        }
    }

}
