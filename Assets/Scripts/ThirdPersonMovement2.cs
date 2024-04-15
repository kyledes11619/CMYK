using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using UnityEngine;

public class ThirdPersonMovement2 : MonoBehaviour
{
    public CharacterController characterController;
    public Transform cam;

    public float speed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool isGrounded;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    Vector3 velocity;

    Animator anim;
    AudioSource audioSource;
    [SerializeField] AudioClip jumpClip;
    [SerializeField] AudioClip swingClip;
    [SerializeField] GameObject protag;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        anim = protag.GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("Swing");
            audioSource.PlayOneShot(swingClip);
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) 
        { 
            velocity.y = -2f;
        }

        if (velocity.y != -2f)
        {
            isGrounded = false;
        }

        if (isGrounded)
        {
            anim.SetTrigger("Grounded");
        }


        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        anim.SetFloat("Speed", Mathf.Abs(direction.x) * speed);

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f); 

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDir.normalized * speed * Time.deltaTime);
            anim.SetFloat("Speed", Mathf.Abs(speed));
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        { 
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            anim.SetTrigger("Jumping");
            anim.ResetTrigger("Grounded");
            audioSource.PlayOneShot(jumpClip);
        }

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }
}
