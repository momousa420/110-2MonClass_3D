using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    public float jumpForce = 10;   //���D�O�D
    public float gravityModifier = 1;   //�t�Ϊ��z���O
    public bool isOnGround = true;   //�O�_���b�a�O�W
    public bool gameOver = false;

    private Animator plAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        plAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            isOnGround = false;
            plAnim.SetTrigger("Jump_trig");

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
            print("�C������!");
        }
            
        }       
}
