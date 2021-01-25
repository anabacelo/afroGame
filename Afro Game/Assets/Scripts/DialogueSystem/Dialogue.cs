using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    public string name;
    public Sprite sprite;

    [TextArea(2,10)]
    public string[] setences;

}
