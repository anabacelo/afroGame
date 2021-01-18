using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    public bool isInGame = true;
    public GameObject[] characterList;
    // Start is called before the first frame update
    void Start()
    {
        if(isInGame){
            characterList = new GameObject[transform.childCount];

            for(int i = 0; i < characterList.Length; i++){
                characterList[i] = transform.GetChild(i).gameObject;
            }

            foreach (GameObject go in characterList){
                go.SetActive(false);
            }

            int index = PlayerPrefs.GetInt("characterSelected",0);

            if(characterList[index]){
                characterList[index].SetActive(true);
            }
        }
    }

    public void confirmButton(){
        Debug.Log(PlayerPrefs.GetInt("characterSelected"));
        SceneManager.LoadScene("Room");
    }

    public void selectPlayer(int index){
        PlayerPrefs.SetInt("characterSelected",index);
    }
}
