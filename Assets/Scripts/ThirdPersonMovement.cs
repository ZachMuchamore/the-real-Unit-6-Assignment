using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;

    public Transform cam;
    public Transform groundCheck;

    public float speed = 5f;
    public float turnSmoothTime = 0.1f;
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    public float jumpHeight = 2f;
    float turnSmoothVelocity;

    public Vector3 velocity;
    public LayerMask groundMask;
    public bool isGrounded;


    private void Start()
    {

    }
    

    // Update is called once per frame
    void Update()
    {
       
        

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            //third person basic movement 
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection * speed * Time.deltaTime);
        }
        //Ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }

        //Jumping 
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        
        //Gravity 
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        
        //Sprinting 
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 15f;
        }
        else
        {
            speed = 5f;

        }
    }
}
