using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

   public CharacterController controller;
   [SerializeField] float speed = 5f;
   [SerializeField] float sprintSpeed = 15f;
   [SerializeField] float gravity = -9.81f;
   [SerializeField] float jump = .5f;

    public Transform groundCheck;
    public float groundDistance = 0.5f;
    public LayerMask groundMask;

    bool isGrounded;
    float horizontal;
    float vertical;
    Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Check character grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Get player input
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        // Movement
        Vector3 walkMove = transform.right * horizontal + transform.forward * vertical;
        controller.Move(walkMove * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //Sprint
        Vector3 sprintMove = transform.right * horizontal + transform.forward * vertical;
        if(Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(sprintMove * sprintSpeed * Time.deltaTime);
        }


        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jump * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
}
