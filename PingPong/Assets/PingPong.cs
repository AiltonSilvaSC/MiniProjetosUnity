using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPong : MonoBehaviour
{
    public float VelocidadeBola = 15f;
    public float VelocidadeBolaAumentaPortHit = 0.2f;

    void Start()
    {
        StartCoroutine(Mover());
    }

    void FixedUpdate()
    {
        if (transform.position.x <= -9.5)
        {
            transform.position = new Vector3(0, 0, 0);
            StartCoroutine(Mover());
        }
        if (transform.position.x >= 9.5)
        {
            transform.position = new Vector3(0, 0, 0);
            StartCoroutine(Mover());
        }
    }

    IEnumerator Mover()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(3f);
        GetComponent<Rigidbody2D>().velocity = Vector2.right * VelocidadeBola;
    }

    float CalcDire(Vector2 bolaPosicao, Vector2 barraPos, float barraAltura)
    {
        return (bolaPosicao.y - barraPos.y) / barraAltura;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "BarraJogador1")
        {
            float y = CalcDire(transform.position, col.transform.position, col.collider.bounds.size.y);
            Vector2 direcao = new Vector2(1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = direcao * VelocidadeBola;
            AumentarVelocidade(VelocidadeBolaAumentaPortHit);
        }
        if (col.gameObject.name == "BarraJogador2")
        {
            float y = CalcDire(transform.position, col.transform.position, col.collider.bounds.size.y);
            Vector2 direcao = new Vector2(-1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = direcao * VelocidadeBola;
            AumentarVelocidade(VelocidadeBolaAumentaPortHit);
        }
    }

    public void AumentarVelocidade(float quantidade)
    {
        VelocidadeBola += quantidade;
    }
}
