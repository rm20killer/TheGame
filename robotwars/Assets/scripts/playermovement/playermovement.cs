using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public CharacterController controller;
    private float speed = 0f;
    public float startspeed = 10f;
    public float sprintspeed = 5f;
    public float gravity = -10f;
    public float jumpHeight = 5f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;

    private void Start()
    {
        speed = startspeed;
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        if (Input.GetButton("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        if (Input.GetButton("Fire1"))
        {
            Debug.Log("shoting");
        }
        else if (Input.GetButton("Fire2"))
        {
            Debug.Log("scopping");
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                speed = speed + sprintspeed;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed = startspeed;
            }
        }
    }

}