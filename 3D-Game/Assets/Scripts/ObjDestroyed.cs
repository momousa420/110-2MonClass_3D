using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjDestroyed : MonoBehaviour
{

    public float leftBound = -15;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x<leftBound && gameObject.CompareTag("Obstracte"))
        {
            Destroy(gameObject);
            print("»ÙÃªª«§R°£");
        }
    }
}
