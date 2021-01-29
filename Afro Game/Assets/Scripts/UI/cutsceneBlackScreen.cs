using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class cutsceneBlackScreen : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] setences;
    private int index;
    public float typingSpeed;
    public GameObject continueButton;
    public List<GameObject> toDisableAndEnable;
    public GameObject startButton;


    private void Start() {
        continueButton.SetActive(false);
        toDisableAndEnable.ForEach(item => item.SetActive(false));
        textDisplay.text = "";
        StartCoroutine(Type());
    }

    private void Update() {
        if(textDisplay.text == setences[index]){
            continueButton.SetActive(true);
        }
    }

    IEnumerator Type(){
        foreach(char letter in setences[index].ToCharArray()){
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void nextSetence(){
        if(index < setences.Length - 1){
            index++;    
            textDisplay.text = "";
            continueButton.SetActive(false);
            StartCoroutine(Type());
        } else {
                textDisplay.text = "";
                continueButton.SetActive(false);
                startButton.SetActive(true);
            }
    }

    public void begin(CanvasGroup cg){
        startButton.SetActive(false);
        StartCoroutine(starting(cg, 0.02f));
    }

    public IEnumerator starting(CanvasGroup cg, float fadeOutSpeed){
        toDisableAndEnable.ForEach(item => item.SetActive(true));
        while(cg.alpha > 0){
            cg.alpha -= 0.01f;
            yield return new WaitForSeconds(fadeOutSpeed);
        }
    }
}
