using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // variável que recebe todo o controle de jogo
    public static GameManager gm;

    [Tooltip("Jogador, se esta variável não for definida, ele procurará o objeto com a tag Player.")]
    public GameObject player;

    // Define os estados possíveis para o jogador.
    public enum gameStates { Jogando, Morto, GameOver, NivelVencido };
    [Tooltip("Qual é o estado atual do jogador?")]
    public gameStates gameState = gameStates.Jogando;

    [Tooltip("Pontuação inicial do jogador.")]
    public int score = 0;
    [Tooltip("O jogador pode vencer a fase? (true/false).")]
    public bool podeVencerNivel = false;

    [Tooltip("Qual a pontuação do jogador para vencer a fase?")]
    public int scoreVencerNivel = 0;

    [Tooltip("Define qual Canvas é a tela principal.")]
    public GameObject telaPrincipal;
    [Tooltip("Campo de texto que mostra os pontos do jogador.")]
    public Text playerScoreText;
    [Tooltip("Define qual Canvas é a tela do Game Over.")]
    public GameObject telaGameOver;
    [Tooltip("Campo de texto que mostra os pontos do jogador.")]
    public Text gameOverScoreText;

    [Tooltip("Define qual Canvas é a tela mostrando que o nível foi vencido.")]
    public GameObject telaVenceuNivel;

    [Tooltip("Define a trilha sonora do jogo")]
    public AudioSource gameSoundtrack;
    [Tooltip("Define qual é o áudio de Game Over")]
    public AudioClip gameOverSFX;

    [Tooltip("Define qual é o áudio de nível vencido")]
    public AudioClip nivelVencidoSFX;

    // define script que define a pontuação do jogador
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        // o Game Manager ainda não foi definido?
        if(gm==null)
            // Então vamos definí-lo
            gm = gameObject.GetComponent<GameManager>();

        // o Player ainda não foi definido?
        if(player==null)
            // Então vamos definí-lo
            player = GameObject.FindWithTag("Player");

        playerController = player.GetComponent<PlayerController>();

        // configura a posição das telas
        Collect(0);

        // desativa as telas não necessárias no início do jogo
        telaGameOver.SetActive(false);
        if (podeVencerNivel)
            // se o jogador pode vencer o nível, desativa essa tela
            telaVenceuNivel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // verifica qual é o estado do jogo
        switch (gameState)
        {
            case gameStates.Jogando:
                // o jogador morreu?
                if (playerController.Vidas < 0)
                {
                    // atualiza o estado do jogo
                    gameState = gameStates.Morto;
                    // determina o score final do jogo
                    gameOverScoreText.text = playerScoreText.text;
                    // muda as telas sendo exibidas
                    telaPrincipal.SetActive(false);
                    telaGameOver.SetActive(true);
                }
                // o nível pode ser vencido e o score do nível foi vencido
                else if (podeVencerNivel && score>=scoreVencerNivel)
                {
                    // atualiza o estado do jogo
                    gameState = gameStates.NivelVencido;
                    // esconde o jogador para parar o jogo
                    player.SetActive(false);
                    // muda as telas sendo exibidas
                    telaPrincipal.SetActive(false);
                    telaVenceuNivel.SetActive(true);
                }
                else if (playerController.Vidas >= 0)
                {
                    score = playerController.Pontos;
                }
                break;
            case gameStates.Morto:
                // ativa a música do Game Over
              //  AudioSource.PlayClipAtPoint(gameOverSFX, gameObject.transform.position);
                // atualiza o status do jogo
                gameState = gameStates.GameOver;
                // 
                player.SetActive(false);
                break;
            case gameStates.NivelVencido:
                // ativa a música do Game Over
              //  AudioSource.PlayClipAtPoint(nivelVencidoSFX, gameObject.transform.position);
                // atualiza o status do jogo
                gameState = gameStates.GameOver;
                break;
            case gameStates.GameOver:
                // por enquanto não faz nada
                break;
        }
    }

    public void Collect(int quantidade)
    {
        score += quantidade;
        if (podeVencerNivel)
            playerScoreText.text = score.ToString() + " de " + scoreVencerNivel.ToString();
        else
            playerScoreText.text = score.ToString();
    }
}
