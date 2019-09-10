using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirMoeda : MonoBehaviour
{
    public int pontosMoeda = 10;
    public bool spawn = false;

    void OnTriggerEnter(Collider colisao)
    {
        Debug.Log("Entrou Trigger");
        if (colisao.gameObject.tag == "Player")
        {
            Debug.Log("Pontos jogador" + colisao.gameObject.GetComponent<PlayerController>().Pontos);
            colisao.gameObject.GetComponent<PlayerController>().somarPontos(pontosMoeda);
            Debug.Log("Pontos jogador atual:" + colisao.gameObject.GetComponent<PlayerController>().Pontos);
            Destroy(this.gameObject);

            if (spawn)
            {
                this.gameObject.GetComponent<SpawnObject>().SpawnNow();
            }
        }
    }

}
