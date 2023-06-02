using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] int damage = 1;
    public float attackRange;
    [SerializeField] float timeBetweenAttacks = 1;
    float nextAttackTime;

    public void AttackTarget(Health target)
    {
        if (Time.time > nextAttackTime)
        {
            nextAttackTime = Time.time + timeBetweenAttacks;
            target.TakeDamage(damage);
        }
    }
}
