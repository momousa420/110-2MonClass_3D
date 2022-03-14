using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obPrefab;

    public Vector3 spawnPos = new Vector3(30, 0, 0);

    public float starDelay = 2;
    public float repeatRate = 3;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnO", starDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnO()
    {
        Instantiate(obPrefab, spawnPos, obPrefab.transform.rotation);
    }
}
