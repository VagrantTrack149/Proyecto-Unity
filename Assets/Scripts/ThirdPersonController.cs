using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;
    public float sprintSpeed = 10f;
    public float dashForce = 400f;
    public float dashTime=0f;
    public float dashDuration=0f;
    public float cooldownDash=2f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.5f;
    public float turnSmoothTime = 0.1f;

    private float turnSmoothVelocity;
    private Vector3 velocity;
    private bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    
    private bool isFpsMode= false;
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.T))
        {
            isFpsMode = !isFpsMode;
            Debug.Log("Cambio de cámara");
        }
        // Check if the player is on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Get input for movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if (isFpsMode)
            {
            // First-person mode 
           if (direction.magnitude >= 0.1f)
        {
            // Calculate the target angle based on camera direction
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : speed;
            controller.Move(moveDir.normalized * currentSpeed * Time.deltaTime);
        }
        Transform cubeTransform = transform.Find("Cube"); 
        if (cubeTransform != null)
        {
            Debug.Log("Cubo encontrado: ");
            cam.position = cubeTransform.position;
            cam.rotation = cubeTransform.rotation;
            Debug.Log(cam.position);
        }
    }
        else
        {
            // Third Person mode
            direction = new Vector3(horizontal, 0f, vertical).normalized;
            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : speed;
                controller.Move(moveDir.normalized * currentSpeed * Time.deltaTime);
            }
            // Update camera position with some offset (adjust as needed)
            cam.position = transform.position - transform.forward * 3f + new Vector3(0, 1.5f, 0);
            cam.rotation = Quaternion.LookRotation(transform.position + transform.forward * 10f);
            Debug.Log(cam.position);
        }

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Dash implementation
        if (Input.GetKeyDown(KeyCode.F) && dashTime <= -cooldownDash) 
        {
            dashTime = dashDuration; 
            Vector3 dashDirection = cam.forward;
            controller.Move(dashDirection * dashForce * Time.deltaTime);
        }
        dashTime -= Time.deltaTime;
        

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
