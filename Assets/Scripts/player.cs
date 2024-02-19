using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public ThirdPersonMovement tpm;
    public bool test;

    //public bool isGrounded;
    public bool isJumping;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();   
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey("w"))
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("sprint", true);
        }
        else
        {
            anim.SetBool("sprint", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && tpm.isGrounded)
        {
            isJumping=true;
            tpm.isGrounded=false;
        }

        DoJump();

    }

    void DoJump()
    {
        print("vel=" + tpm.velocity.y);

        if (isJumping && tpm.velocity.y <= 0)
        {
            anim.SetBool("jump", true);

            if( tpm.isGrounded == true )
            {
                isJumping = false;
                anim.SetBool("jump", false);
            }
        }

    }
}
