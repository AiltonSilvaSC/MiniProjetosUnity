using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour
{

    private Text cronometroText;
    private bool funcionar = true;
    private int tempo = 0;

    void Start()
    {
        cronometroText = GetComponent<Text>();
        cronometroText.text = "0";
        StartCoroutine(Rodar());
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (funcionar == true)
            {
                funcionar = false;
                print("Cronometro Pausado");
            }
            else
            {
                funcionar = true;
                StartCoroutine(Rodar());
                print("Cronometro Despausado");
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            tempo = 0;
            CronometroAtualizar();
            print("Cronometro Resetado");
        }
    }

    IEnumerator Rodar()
    {
        while (funcionar)
        {
            tempo++;
            CronometroAtualizar();
            yield return new WaitForSeconds(1);
        }
    }

    private void CronometroAtualizar()
    {
        cronometroText.text = tempo.ToString();
    }
}
