using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Vector2 moveInput,startPos;
    private Renderer playerRenderer;
    // Start is called before the first frame update
    void Start()
    {
        startPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        rb = GetComponent<Rigidbody2D>();
        playerRenderer = GetComponent<Renderer>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * speed, moveInput.y * speed).normalized;
    }
    private void Update()
    {
        if (!playerRenderer.isVisible)
        {
            Debug.Log("PlayerOutOfRange");
        }
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {   
        if (collision.gameObject.CompareTag("wall"))
        {
            gameObject.transform.position = startPos;
        }
    }
}
