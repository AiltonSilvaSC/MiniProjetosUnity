using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotaoTimer : MonoBehaviour
{

    private Text textoBotao;
    [SerializeField] // Pega pelo unity
    private Timer timerControler;

    void Start()
    {
        Transform texto = transform.Find("Text");
        textoBotao = texto.GetComponent<Text>();

        Button btn = transform.GetComponent<Button>();
        btn.onClick.AddListener(Clicou);
    }

    private void Clicou()
    {
        if (textoBotao.text == "Pause")
            timerControler.isFuncionando = false;
        if (textoBotao.text == "Start")
            timerControler.isFuncionando = true;
        if (textoBotao.text == "Reset")
        {
            timerControler.tempo = 60f;
            timerControler.CronometroAtualizar();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timerControler.isFuncionando && timerControler.tempo > 0)
        {
            textoBotao.text = "Pause";
        }

        if (!timerControler.isFuncionando && timerControler.tempo > 0)
        {
            textoBotao.text = "Start";
        }

        if (!timerControler.isFuncionando && timerControler.tempo == 0)
        {
            textoBotao.text = "Reset";
        }
    }
}
