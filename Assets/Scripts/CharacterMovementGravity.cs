using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementGravity : MonoBehaviour
{
    public float speed = 5f; 
    public float jumpForce = 10f; 
    public float gravity = 9.81f; 

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; 
    }

    void Update()
    {
        MoveCharacter();
        ApplyGravity();
        CheckGrounded();

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))
        {
            if (isGrounded)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }

    void MoveCharacter()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        if (movement.magnitude >= 0.1f)
        {
           
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.15f);
          
            Vector3 moveDirection = transform.forward * speed * Time.deltaTime;
            rb.MovePosition(transform.position + moveDirection);
        }
    }

    void ApplyGravity()
    {
     
        rb.AddForce(Vector3.down * gravity, ForceMode.Acceleration);
    }

    void CheckGrounded()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.1f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}