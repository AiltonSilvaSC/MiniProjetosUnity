using UnityEngine;

public class DestruirPlayer : MonoBehaviour
{
    [SerializeField]
    private int destruirVidas = 1;

    void OnCollisionEnter(Collision colisao)
    {
        if (colisao.gameObject.tag == "Player")
        {
            if (this.gameObject.tag == "Cacador")
            {
                Debug.Log("EnterCollision");
                colisao.gameObject.GetComponent<PlayerController>().subtrairVidas(10);
                Debug.Log("Vidas jogador:" + colisao.gameObject.GetComponent<PlayerController>().Vidas);
            }
            else
            {

                colisao.gameObject.GetComponent<PlayerController>().subtrairVidas(destruirVidas);
            }
        }
    }

    void OnCollisionStay(Collision colisao)
    {
        if (colisao.gameObject.tag == "Player" && colisao.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("StayCollision");
            PlayerController playerController = colisao.gameObject.GetComponent<PlayerController>();
            playerController.subtrairVidas(10);
            playerController.Salvar();

            Destroy(playerController.gameObject);
        }
    }
}

