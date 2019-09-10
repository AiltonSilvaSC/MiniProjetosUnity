
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float velocidade = 10.0f;
    [SerializeField]
    public static int pontos = 0;
    [SerializeField]
    private static int vidas = 2;
    static string arqScoreDB = @"score.json";

    //public Text uiPontos;

    public int Pontos
    {
        get { return pontos; }
        set { pontos = value; }
    }

    public int Vidas
    {
        get { return vidas; }
        set { vidas = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //uiPontos.text = "" + pontos.ToString();
    }

    void FixedUpdate()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");

        Vector3 movimento = new Vector3(movimentoHorizontal, 0.0f, movimentoVertical);

        rb.AddForce(movimento * velocidade);
    }

    public void somarPontos(int p)
    {
        Pontos += p;
    }
    public void subtrairPontos(int p)
    {
        Pontos -= p;
    }
    public void somarVidas(int v)
    {
        Vidas += v;
    }
    public void subtrairVidas(int v)
    {
        Vidas -= v;
    }


    public void Salvar()
    {
        Debug.Log("Salvar o JSON");

        try
        {
            // verifica se o arquivo existe
            StreamReader sr = new StreamReader(arqScoreDB);
            // se o arquivo não existir, esta parte do código
            // não será executada
            // lê os dados do arquivo para uma variável temporária
            string json = sr.ReadToEnd();
            // fecha o arquiv
            
            sr.Close();
            List<int> lista = JsonUtility.FromJson<List<int>>(json);
            // adiciona os dados do jogador atual à lista lida do arquivo
            lista.Add(pontos);
            
            // ordena a lista pela pontuação
            lista.Sort(
            delegate (int j1, int j2)
            {
                return j2.CompareTo(j1);
            }
            );
            // remove os itens excedentes da lista
            for (int i = (lista.Count - 1); i > 4; i--)
                lista.RemoveAt(i);
            // grava a lista atualizada no banco de dados
            string jSonObject = JsonUtility.ToJson(lista);
            Debug.Log("Salvar o JSON 2: " + jSonObject.ToString());
            // cria o arquivo no mesmo lugar em que o jogo está sendo executado
            StreamWriter sw = new StreamWriter(arqScoreDB);
            sw.Write(jSonObject);
            // fecha o arquivo
            sw.Close();

        }
        catch
        {
            // cria uma lista de jogadores, prevendo que novos jogadores
            // serão adicionados ao score
            List<int> lista = new List<int>();
            // adiciona os dados do jogador atual à lista
            lista.Add(Pontos);
            Debug.Log("Salvar o JSON");
            // transforma a lista em uma informação no formato json:
            // [{"Nome":"<nome-digitado>","Pontos":<pontos-acumulados>}]
            string jSonObject = JsonUtility.ToJson(lista);
            // cria o arquivo no mesmo lugar em que o jogo está sendo executado
            StreamWriter sw = new StreamWriter(arqScoreDB);
            // escreve os dados no formato JSON
            sw.Write(jSonObject);
            // fecha o arquivo
            sw.Close();
        }

    }
}