using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    public float moveSpeed;
    public float jumpForce;
    public float sprintMultiplier;

    public bool isGrounded;
    public LayerMask Ground;
    public GameObject GroundCheck;

    public Transform orientation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.rotation = orientation.rotation;

        //input
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float y = Input.GetAxis("Vertical") * moveSpeed;

        //moving
        Vector3 movePos = orientation.right * x + orientation.forward * y;
        Vector3 newMovePos = new Vector3(movePos.x, rb.velocity.y, movePos.z);
        if (isGrounded)
        {
            rb.velocity = newMovePos;
        }

        //Grounded
        isGrounded = Physics.CheckSphere(GroundCheck.transform.position, 0.2f, Ground);

        //sprinting
        if (Input.GetKeyDown(KeyCode.LeftShift))
            moveSpeed *= sprintMultiplier;
        else if (Input.GetKeyUp(KeyCode.LeftShift))
            moveSpeed /= sprintMultiplier;

        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }
}
