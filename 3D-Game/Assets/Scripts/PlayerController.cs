using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    public float jumpForce = 10;   //跳躍力道
    public float gravityModifier = 1;   //系統物理重力
    public bool isOnGround = true;   //是否站在地板上
    public bool gameOver = false;
    public ParticleSystem pl_Explosion;
    public ParticleSystem pl_Dirty;

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
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            isOnGround = false;
            plAnim.SetTrigger("Jump_trig");
            pl_Dirty.Stop();

        }
    }

    private void OnCollisionEnter(Collision other) 
        {
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            pl_Dirty.Play();
        }
        else if (other.gameObject.CompareTag("Obstracte"))
        {
            gameOver = true;

            //print("遊戲結束!");
            pl_Explosion.Play();

            plAnim.SetBool("Death_b", true);
            plAnim.SetInteger("DeathType_int", 1);
            pl_Dirty.Stop();
        }
            
        }       
}
