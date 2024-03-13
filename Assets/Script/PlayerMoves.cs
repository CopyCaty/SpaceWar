using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoves : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    
    public Transform orientation;

    float horizontalInput;
    float verticalInput;
    float jumpInput;
    Vector3 moveDirection;
    Rigidbody rb;
    public Text speedText;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        jumpInput = Input.GetAxisRaw("Jump");
    }

    private void Update()
    {
        MyInput();
        if(rb.velocity.magnitude < 0.01)
        {
            rb.drag = 0;
        }
        else
        {
            rb.drag = 2f;
        }
    }
    private void FixedUpdate()
    {
        MovePlayer();
        SpeedControl();
        speedText.text = "Speed: " + rb.velocity.magnitude;
    }
    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput + orientation.up * jumpInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 5f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z);
        if(velocity.magnitude > moveSpeed)
        {
            Vector3 limitedVelocity = velocity.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, limitedVelocity.y, limitedVelocity.z);
        }
    }
}
