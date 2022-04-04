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
    //定義控制爆炸力子物件的變數
    public ParticleSystem pl_Explosion;
    public ParticleSystem pl_Dirty;

    private Animator plAnim;

    public AudioClip ac_jump;
    public AudioClip ac_explsion;
    private AudioSource as_player;
    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier; //等同Physics.gravity * Physics.gravity
        //將遊戲物件的 Animator 元件掛載到 plAnim變數上，有「啟動此變數」的意思
        plAnim = GetComponent<Animator>();
        as_player = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //跳躍行為設定
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            isOnGround = false;
            plAnim.SetTrigger("Jump_trig"); 
            pl_Dirty.Stop();
            as_player.PlayOneShot(ac_jump,1.0f);
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
            print("遊戲結束!");
            
            //設定死亡動畫
            plAnim.SetBool("Death_b", true);
            plAnim.SetInteger("DeathType_int", 1);
            pl_Explosion.Play();
            pl_Dirty.Stop();
            as_player.PlayOneShot(ac_explsion,1.0f);
        }
            
        }       
}
