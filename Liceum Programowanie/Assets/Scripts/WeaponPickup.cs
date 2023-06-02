using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public string weapon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        WeaponsTest weapons = collision.GetComponent<WeaponsTest>();
        if(weapons)
        {
            weapons.PickUpWeapon(weapon);
            Destroy(gameObject);
        }
    }
}
