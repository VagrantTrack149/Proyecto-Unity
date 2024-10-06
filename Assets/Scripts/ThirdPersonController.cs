using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public Animator animator;
    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;
    public float sprintSpeed = 10f;
    public float dashForce = 400f;
    public float dashTime = 0f;
    public float dashDuration = 0f;
    public float cooldownDash = 2f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.5f;
    public float turnSmoothTime = 0.1f;

    private float turnSmoothVelocity;
    private Vector3 velocity;
    private bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    void Update()
    {
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

        // Get input for movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : speed; 
            controller.Move(moveDir.normalized * currentSpeed * Time.deltaTime);
            animator.SetBool("IsRun",true);
        }else
        {animator.SetBool("IsRun",false);}

        cam.position = transform.position - transform.forward * 3f + new Vector3(0, 1.5f, 0);
        cam.rotation = Quaternion.LookRotation(transform.position + transform.forward * 10f);

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        // Dash 
        if (Input.GetKeyDown(KeyCode.F) && dashTime <= -cooldownDash)
        {
            dashTime = dashDuration;
            Vector3 dashDirection = cam.forward;
            controller.Move(dashDirection * dashForce * Time.deltaTime);
        }
        dashTime -= Time.deltaTime;

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        animator.SetBool("IsStanding",direction.magnitude <= 0);
    }
}
