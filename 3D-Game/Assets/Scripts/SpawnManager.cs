using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obPrefab;

    public Vector3 spawnPos = new Vector3(30, 0, 0);

    public float starDelay = 2;
    public float repeatRate = 3;

    private PlayerController PController;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnO", starDelay, repeatRate);
        PController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnO()
    {
        if (PController.gameOver == false)
        {
            Instantiate(obPrefab[0], spawnPos, transform.rotation);
        }
       
    }
}
