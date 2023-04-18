using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    #region Variables
    private Inputs input;
    public float speed = 1;
    [SerializeField]float jumpForce=5,groundCheckDistance=0.5f;
    private float currentJumpForce;
    private Vector3 velocity;
    private Rigidbody rb;
    private InputAction turning;
    [SerializeField] LayerMask groundLayer;
    bool crouching;
    #endregion
    #region inputInit
    private void Awake()
    {
        input = new Inputs();
    }
    private void OnEnable()
    {
        turning = input.Player.Move;
        input.Player.Jump.performed += Jump;
        input.Player.Crouch.performed+=Crouch;
        input.Player.Enable();
    }
    private void OnDisable()
    {
        input.Player.Disable();
        input.Player.Jump.performed -= Jump;
    }

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(turning.ReadValue<Vector2>().x + 0, 0, speed) * Time.deltaTime);
    }
    void Jump(InputAction.CallbackContext context)
    {
        //bool isGrounded;
        //Debug.Log(Physics.Raycast(transform.position, -Vector3.up, groundCheckDistance, groundLayer));
        //isGrounded = Physics.Raycast(transform.position, -Vector3.up, groundCheckDistance, groundLayer);
        //if (isGrounded)
        //{
        
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
        //}
    }
    void Crouch(InputAction.CallbackContext callback)
    {
        if (!crouching)
        {
            GetComponent<Transform>().localScale = new Vector3(1, 0.5f, 1);
            crouching = true;
        }
        else
        {
            GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
            crouching = false;
        }
    }
}
