using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Third_Person_Movement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of character movement
    public float jumpForce = 10f; // Force applied when jumping
    public Transform mainCamera; // Reference to the main camera

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to center of screen
        Cursor.visible = false; // Hide cursor
    }

    void Update()
    {
        // Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = (mainCamera.forward * verticalInput + mainCamera.right * horizontalInput).normalized;
        moveDirection.y = 0f; // Ensure no vertical movement
        rb.MovePosition(transform.position + moveDirection * moveSpeed * Time.deltaTime);

        // Jumping
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Rotation
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * mouseX);

        // Camera following
        mainCamera.position = transform.position + Vector3.up * 2f; // Adjust camera position relative to character
        mainCamera.rotation = Quaternion.LookRotation(transform.forward, Vector3.up); // Rotate camera to always face forward
    }

    bool IsGrounded()
    {
        RaycastHit hit;
        float distance = 0.1f;
        Vector3 dir = Vector3.down;

        if (Physics.Raycast(transform.position, dir, out hit, distance))
        {
            return true;
        }
        return false;
    }
}

