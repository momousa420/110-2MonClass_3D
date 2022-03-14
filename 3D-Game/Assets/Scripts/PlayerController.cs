using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    public float jumpForce = 10;   //跳躍力道
    public float gravityModifier = 1;   //系統物理重力
    public bool isOnGround = true;   //是否站在地板上
    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            isOnGround = false;

        }
    }

    private void OnCollisionEnter(Collision other) 
        {
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (other.gameObject.CompareTag("Obstracte"))
        {
            gameOver = true;
            print("遊戲結束!");
        }
            
        }       
}
