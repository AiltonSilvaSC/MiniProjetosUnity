using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    private Text timerText;
    public bool isFuncionando = true;
    public float tempo = 5f;

    void Start()
    {
        timerText = GetComponent<Text>();
        CronometroAtualizar();
    }

    private void FixedUpdate()
    {
        if (isFuncionando)
        {
            tempo -= Time.deltaTime;
            CronometroAtualizar();
        }
        if (tempo <= 0)
        {
            isFuncionando = false;
            tempo = 0f;
            CronometroAtualizar();
        }
    }

    public void CronometroAtualizar()
    {
        timerText.text = tempo.ToString();
    }
}
