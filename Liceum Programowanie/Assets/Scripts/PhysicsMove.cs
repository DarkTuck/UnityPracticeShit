using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMove : MonoBehaviour
{
    public float moveSpeed = 5;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 inputVector = Vector2.zero;
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");
        inputVector = new Vector2(xInput, yInput);
        //inputVector.Normalize();
        if(inputVector.magnitude > 1)
        {
            inputVector = inputVector.normalized;
        }

        inputVector = Vector2.ClampMagnitude(inputVector, 1);

        //if(Input.GetKey(KeyCode.D))
        //{
        //    //rb.AddForce(Vector2.right * 5);
        //    inputVector = Vector2.right;
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    //rb.AddForce(Vector2.left * 5);
        //    inputVector = Vector2.left;
        //}
        rb.velocity = inputVector * moveSpeed;
    }

}
