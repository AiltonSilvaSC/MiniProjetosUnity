using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 distanciaPlayer;

    // Start is called before the first frame update
    void Start()
    {
        distanciaPlayer = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + distanciaPlayer;
    }
}
