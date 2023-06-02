using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3D : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5;
    [SerializeField] float jumpSpeed = 5;
    [SerializeField] float groundCheckRange = 0.1f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] BoxCollider col;
    bool jumpPressed;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded())
            {
                jumpPressed = true;
            }
        }
    }

    void FixedUpdate()
    {
        Vector2 moveInput = new Vector2( Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveInput = Vector2.ClampMagnitude(moveInput, 1);
        Vector3 moveDirection = Vector3.right * moveInput.x + Vector3.forward * moveInput.y;
        Vector3 desiredVelocity = moveDirection * moveSpeed;
        if(jumpPressed)
        {
            desiredVelocity.y = jumpSpeed;
            jumpPressed = false;
        }
        else
        {
            desiredVelocity.y = rb.velocity.y;
        }
        rb.velocity = desiredVelocity;
    }

    bool IsGrounded()
    {
        Vector3 extents = col.bounds.extents;
        return Physics.CheckBox(transform.position + Vector3.down * groundCheckRange, extents,
            transform.rotation, groundLayer); 
    }

    private void OnDrawGizmosSelected()
    {
        if(IsGrounded())
        {
            Gizmos.color = Color.green;
        }
        else
        Gizmos.color = Color.red;

        Vector3 extents = col.bounds.extents;
        Gizmos.DrawWireCube(transform.position + Vector3.down * groundCheckRange, extents*2);
    }
}
