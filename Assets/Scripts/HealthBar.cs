using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] int HP;
    Slider healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Slider>();
        SetMaxHealth(HP);
    }
    public void SetMaxHealth(int maxHealth)
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
    }
    private void SetHealth(int health)
    {
        healthBar.value = health;
    }
    public void SetHP(int health)
    {
        HP += health;
        SetHealth(HP);
    }
}
