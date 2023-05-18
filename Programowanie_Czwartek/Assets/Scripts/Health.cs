using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] Image healthBar;
    [SerializeField] int maxHealth;
    private int currentHealth;

    [SerializeField] UnityEvent onDeath;
    [SerializeField] UnityEvent onDamaged;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        onDamaged.Invoke();
        if(healthBar)
        {
            healthBar.fillAmount = (float)currentHealth / maxHealth;
        }

        if(currentHealth <= 0)
        {
            onDeath.Invoke();
        }
    }
}
