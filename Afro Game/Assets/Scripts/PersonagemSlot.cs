using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PersonagemSlot : MonoBehaviour
{        
        public static int indexChar = -1;
        public void SelectCharacter(int index){ 
            indexChar = index;
            SceneManager.LoadScene("Room");

        }
}