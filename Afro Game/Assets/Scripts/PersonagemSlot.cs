using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PersonagemSlot : MonoBehaviour
{        
        private int selectedCharacterIndex;
        private Color desiredColor;

        
        [Header("Lista de personagens")]
        [SerializeField] private List<CharacterSelectObject> charaterList = new List<CharacterSelectObject>();

        [Header("UI References")]
        [SerializeField] private TextMeshProUGUI characterName;
        [SerializeField] private Image characterSplash;
        [SerializeField] private Image backgroundColor;


        private void Start(){
            UpdateCharacterSelectionUi();
        }

        public void LeftArrow(){
            selectedCharacterIndex--;
            if(selectedCharacterIndex < 0){
                selectedCharacterIndex = charaterList.Count -1;
            }
            UpdateCharacterSelectionUi();
        }

        public void RightArrow(){
            selectedCharacterIndex++;
            if(selectedCharacterIndex ==charaterList.Count){
                selectedCharacterIndex = 0;
            }
            UpdateCharacterSelectionUi();
        }

        private void UpdateCharacterSelectionUi(){
            characterSplash.sprite = charaterList[selectedCharacterIndex].splash;
            characterName.text = charaterList[selectedCharacterIndex].characterName;
        }

        [System.Serializable]
        public class CharacterSelectObject{
            public Sprite splash;
            public string characterName;


        }
}