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

        anim.SetBool("walk", false);
        anim.SetBool("sprint", false);

        if ((Input.GetKey("w") == true) || (Input.GetKey("a") == true) || (Input.GetKey("s") == true) || (Input.GetKey("d") == true))
        {
            // check for shift
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("sprint", true);
            }
            else
            {
                anim.SetBool("walk", true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && tpm.isGrounded)
        {
            isJumping=true;
            //tpm.isGrounded=false;
        }
      
        DoJump();

    }

    void DoJump()
    {

        if (isJumping == true )
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
