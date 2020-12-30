using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PersonagemSlot : MonoBehaviour
{        
        [SerializeField]
        GameObject Selector;
        [SerializeField]
        GameObject[] col1;
        [SerializeField]
        GameObject[] col2;

        const int collum = 2;

        int positionRow;
        List<int> charList = new List<int>();
        public GameObject[] rows= new GameObject[collum];
        GameObject currentChar;

        void AddRowtoRowArray(int index, GameObject[] col){
            for (int i = 0; i < 2; i++)
            {
                rows[index] = col[i];
            }
        }


        void Start(){
            AddRowtoRowArray(0,col1);
            AddRowtoRowArray(1,col2);
        }

        void Update(){

        }













        // private int selectedCharacterIndex;
        // private Color desiredColor;

        
        // [Header("Lista de personagens")]
        // [SerializeField] private List<CharacterSelectObject> charaterList = new List<CharacterSelectObject>();

        // [Header("UI References")]
        // [SerializeField] private TextMeshProUGUI characterName;
        // [SerializeField] private Image characterSplash;
        // [SerializeField] private Image backgroundColor;


        // private void Start(){
        //     UpdateCharacterSelectionUi();
        // }

        // public void LeftArrow(){
        //     selectedCharacterIndex--;
        //     if(selectedCharacterIndex < 0){
        //         selectedCharacterIndex = charaterList.Count -1;
        //     }
        //     UpdateCharacterSelectionUi();
        // }

        // public void RightArrow(){
        //     selectedCharacterIndex++;
        //     if(selectedCharacterIndex ==charaterList.Count){
        //         selectedCharacterIndex = 0;
        //     }
        //     UpdateCharacterSelectionUi();
        // }

        // private void UpdateCharacterSelectionUi(){
        //     characterSplash.sprite = charaterList[selectedCharacterIndex].splash;
        //     characterName.text = charaterList[selectedCharacterIndex].characterName;
        // }

        // [System.Serializable]
        // public class CharacterSelectObject{
        //     public Sprite splash;
        //     public string characterName;

        // }

        // public int SelectedCharacter(){
            
        //     PlayerPrefs.SetInt(string.Format("Personagem{0}"), selectedCharacterIndex);

        //     return selectedCharacterIndex;
        // }
}