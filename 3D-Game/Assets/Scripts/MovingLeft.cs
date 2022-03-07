using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLeft : MonoBehaviour
{
    public float speed = 10;    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
