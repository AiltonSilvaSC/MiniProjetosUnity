using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject spawnPrefab;
    public float tempoMinimoEntreSpawn = 3.0f;
    public float tempoMaximoEntreSpawn = 6.0f;

    private float segundosEntreSpawn;
    private float momentoSpawn;

    // Start is called before the first frame update
    void Start()
    {
        momentoSpawn = Time.time;
        segundosEntreSpawn = Random.Range(tempoMinimoEntreSpawn, tempoMaximoEntreSpawn);        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.time - momentoSpawn) >= segundosEntreSpawn)
        {
            SpawnNow();
            
            momentoSpawn = Time.time;
            segundosEntreSpawn = Random.Range(tempoMinimoEntreSpawn, tempoMaximoEntreSpawn);
        }
    }

    public void SpawnNow()
    {
        Vector3 posicao = new Vector3();
        posicao.y = 1.2f;
        posicao.x = Random.Range(-24, +24);
        posicao.z = Random.Range(-24, +24);
        GameObject clone = Instantiate(spawnPrefab, posicao, transform.rotation) as GameObject;
    }
}
