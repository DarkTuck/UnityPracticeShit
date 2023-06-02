using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] StatusBar healthBar;
    [SerializeField] int maxHealth;
    private int currentHealth;

    [SerializeField] UnityEvent onDeath;
    [SerializeField] UnityEvent onDamaged;

    void Start()
    {
        currentHealth = maxHealth;
        if(healthBar)
        healthBar.SetBarValue(maxHealth, currentHealth);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        onDamaged.Invoke();
        if(healthBar)
        {
            healthBar.SetBarValue(currentHealth, maxHealth);
        }

        if(currentHealth <= 0)
        {
            onDeath.Invoke();
        }
    }
}
