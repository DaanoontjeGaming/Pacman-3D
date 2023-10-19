using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float GroundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;
    public Transform orientation;

    private float horizontalInput;
    private float verticalInput;
    private Vector3 moveDirection;
    private Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component attached to the player GameObject.
        rb = GetComponent<Rigidbody>();
    }

    void MyInput()
    {
        // Get input for player movement using WASD keys or arrow keys.
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    void MovePlayer()
    {
        // Calculate the movement direction based on player orientation.
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // Apply a force to move the player using Rigidbody.
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    void Update()
    {
        //Call de functies die de input en speed regelen.
        MyInput();
        SpeedControl();

    }

    void FixedUpdate()
    {
        //Call de functie die de player laat bewegen.   
        MovePlayer();
    }
}