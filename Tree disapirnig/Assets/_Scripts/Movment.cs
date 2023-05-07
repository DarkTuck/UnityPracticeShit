using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movment : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody rb;
    private Vector2 moveInput;
    private Renderer playerRenderer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(moveInput.x,0,moveInput.y).normalized * speed;
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}