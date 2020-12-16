using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndlessUIManager : MonoBehaviour
{
    public Image[] lifeHearts;

    public void UpdateLifes(int lives){
        for (int i = 0; i < lifeHearts.Length; i++)
        {
            if(lives > i){
                lifeHearts[i].color = Color.white;
            }else {
                lifeHearts[i].color = Color.black;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
