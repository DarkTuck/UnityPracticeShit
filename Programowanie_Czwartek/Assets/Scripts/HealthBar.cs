using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;

public class HealthBar : MonoBehaviour
{
    [SerializeField] float MaxHP, MinHP;
    [ShowNonSerializedField]float HP;
    Slider healthBar;
    // Start is called before the first frame update
    void Start()
    {
        HP = MaxHP;
        healthBar = GetComponent<Slider>();
    }
    private void SetHealth(float health)
    {
        healthBar.value = health;
    }
    public void SetHP(int health)
    {
        HP=Mathf.Clamp(HP += health,MinHP,MaxHP);
        SetHealth(HP / 100);
    }
}
