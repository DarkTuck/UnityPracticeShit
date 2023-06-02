using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    Health health;
    private void Start()
    {
        health = GetComponent<Health>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        health.TakeDamage(1);
        collision.GetComponent<Enemy>()?.OnDeath();
        Destroy(collision.gameObject);
    }
}
