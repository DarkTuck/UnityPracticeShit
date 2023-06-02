using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    [Header("Health")]
    public Health health;

    Animator animator;
    bool isAlive = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(isAlive)
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        health.TakeDamage(1);
    }

    public void OnDeath()
    {
        isAlive = false;
        animator.SetTrigger("Death");
        GetComponent<Collider2D>().enabled = false;
        EnemyManager enemyManager = FindObjectOfType<EnemyManager>();
        if (enemyManager)
        {
            enemyManager.OnEnemyKilled(this);
        }
      
    }

    public void OnFinishDeathAnimation()
    {
        Destroy(gameObject);
    }


}
