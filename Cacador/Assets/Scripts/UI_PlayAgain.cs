using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_PlayAgain : MonoBehaviour
{

    public string executarNivel;

    public void ExecutarNivel()
    {
        SceneManager.LoadScene(executarNivel);
    }

}
