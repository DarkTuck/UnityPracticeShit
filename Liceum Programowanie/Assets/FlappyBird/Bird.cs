using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpPower = 1;
    public PlayerScore scoreManager;
    public GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Druga metoda znajdywania obiektu ze skryptem
        //scoreManager = FindObjectOfType<PlayerScore>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Flap();
        }
    }

    void Flap()
    {
        rb.velocity = Vector2.up * jumpPower;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.OnPlayerDeath();
        Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        scoreManager.AddPoint();
        //Druga metoda
        //scoreManager.score++;
    }

}
