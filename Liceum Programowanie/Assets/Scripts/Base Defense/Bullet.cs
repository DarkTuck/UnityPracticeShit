using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int damage = 1;
    private float speed = 10;
    [SerializeField] float lifeTime = 10;

    public void Init(BulletStats bulletStats)
    {
        damage = bulletStats.damage;
        speed = bulletStats.bulletSpeed;
    }

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }


    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Health otherHealth = other.GetComponent<Health>();
        if(otherHealth)
        {
            otherHealth.TakeDamage(damage);
        }
    }
}
