using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cena : MonoBehaviour
{
    public void MudarCena(int indice)
    {
        SceneManager.LoadScene(indice);
    }
}
