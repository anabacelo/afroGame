using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Playables;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Image m_Image;
    public float typeSpeed = 0.02f;
    public Dialogue[] nextDialogues;
    //public GameObject nextDialogueTrigger;

    public Animator animatorUI;
    public Animator anim;
    public string especialAnim;
    public int indexOfEspecialAnim;
    public PlayableDirector endCutscene;
    private bool isPlayed;

    private int nextDialoguesIndex;
    private Queue<string> setences;

    private void Start() {
        setences = new Queue<string>();
        nextDialoguesIndex = 0;
        isPlayed = false;
    }

    public void StartDialogue(Dialogue dialogue){
        animatorUI.SetBool("isOpen", true);
        m_Image.sprite = dialogue.sprite;
        Debug.Log("count sentences starting " + dialogue.setences.Length);
        Debug.Log("Starting conversation with " + dialogue.name);
        nameText.text = dialogue.name;
        setences.Clear();

        foreach (string setence in dialogue.setences)
        {
            setences.Enqueue(setence);
        }

        DisplayNextSetence();
    }

    public void DisplayNextSetence(){
        //Debug.Log("count Queue sentences first " + setences.Count);
        if(setences.Count == 0){
            EndDialogue();
            return;
        }
        string setence = setences.Dequeue();
        //Debug.Log("count Queue sentences after " + setences.Count);

        anim.SetBool("isTalking", true);
        
        StopAllCoroutines();
        StartCoroutine(TypeSetence(setence));
        
        Debug.Log(setence);

    }

    IEnumerator TypeSetence(string setence){
        dialogueText.text = "";
        foreach(char letter in setence.ToCharArray()){
            dialogueText.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }

        anim.SetBool("isTalking", false);
    }

    public void EndDialogue(){
        animatorUI.SetBool("isOpen",false);

        if(nextDialoguesIndex < nextDialogues.Length){
            Debug.Log("indexOfEspecialAnim " + indexOfEspecialAnim + " nextDialoguesIndex " + nextDialoguesIndex);
            if(indexOfEspecialAnim == nextDialoguesIndex){
                Debug.Log("passou " + especialAnim);
                anim.SetBool(especialAnim, true);  
                anim.SetBool(especialAnim, false);      
            }
            
            StartDialogue(nextDialogues[nextDialoguesIndex]);
            nextDialoguesIndex++;
        }else if(endCutscene != null && !isPlayed){
            isPlayed = true;
            anim.gameObject.SetActive(false);
            endCutscene.Play();
        }
        
        Debug.Log("End Conversation");
    }
}
