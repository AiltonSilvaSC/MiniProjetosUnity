using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cacar : MonoBehaviour
{

    public float velocidade = 20.0f;
    public float distanciaMinina = 1f;
    public Transform alvo;

    // Start is called before the first frame update
    void Start()
    {
        if (alvo == null)
        {
            if (GameObject.FindWithTag("Player") != null)
            {
                alvo = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (alvo == null)
        {
            Debug.Log("Não há alvo definido para caçar!!!");
            return;
        }

        transform.LookAt(alvo);

        float distancia = Vector3.Distance(transform.position, alvo.position);

        if (distancia > distanciaMinina)
            transform.position += transform.forward * velocidade * Time.deltaTime;
    }

    public void setAlvo(Transform novoAlvo)
    {
        alvo = novoAlvo;
    }
}
