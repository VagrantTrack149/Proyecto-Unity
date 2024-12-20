using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorV2 : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Animator animator;
    public float speed=20.0f;
    public float turnSmoothTime=0.1f;
    float turnSmoothVelocity=0.1f;
    private bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float gravity = -9.81f;
    private Vector3 velocity;
    public float jumpHeight = 10f;
    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update(){
        float horizontal=Input.GetAxisRaw("Horizontal");
        float vertical=Input.GetAxisRaw("Vertical");
        Vector3 direction= new Vector3(horizontal, 0,vertical).normalized;
        if (direction.magnitude >= 0.1f){
            float targetAngle=Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation=Quaternion.Euler(0f,angle,0f);
            Vector3 moveDir=Quaternion.Euler(0f,targetAngle,0f)*Vector3.forward;
            controller.Move(moveDir.normalized*speed*Time.deltaTime);
            animator.SetBool("IsRun",true);
        }else{
            animator.SetBool("IsRun",false);
        }
        //Suelo y salto
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded){
            animator.SetBool("IsJump", false);
        }else{
            animator.SetBool("IsJump", true);
        }
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        animator.SetBool("IsStanding",direction.magnitude <= 0);
    }
}
