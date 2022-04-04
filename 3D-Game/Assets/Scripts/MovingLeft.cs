using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLeft : MonoBehaviour
{
    public float speed = 10;
    public float leftBound = -15;

    private PlayerController PCScript;
    
    void Start()
    {
        PCScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    
    void Update()
    {
        if (PCScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstracte"))
        {
            //Destroy(gameObject);
            print("»ÙÃªª«§R°£");
        }
    }
}
