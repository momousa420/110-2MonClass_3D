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
    //�w�q�����z���O�l�����ܼ�
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
        Physics.gravity *= gravityModifier; //���PPhysics.gravity * Physics.gravity
        //�N�C������ Animator ���󱾸��� plAnim�ܼƤW�A���u�Ұʦ��ܼơv���N��
        plAnim = GetComponent<Animator>();
        as_player = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //���D�欰�]�w
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
            print("�C������!");
            
            //�]�w���`�ʵe
            plAnim.SetBool("Death_b", true);
            plAnim.SetInteger("DeathType_int", 1);
            pl_Explosion.Play();
            pl_Dirty.Stop();
            as_player.PlayOneShot(ac_explsion,1.0f);
        }
            
        }       
}
