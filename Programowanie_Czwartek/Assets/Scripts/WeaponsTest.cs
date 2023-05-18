using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsTest : MonoBehaviour
{
    //public string[] weapons = new string[] { "Pistol", "Shotgun", "Snipier" };
    public List<string> weapons = new List<string>();
    int weaponIndex;
    private void Start()
    {
        //weapons[0] = "Pistol";
        //weapons[1] = "Shotgun";
        //weapons[2] = "Snipier Rifle";
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //wypisz nazwê obecnej broni
            if(weapons.Count>0)
            {
                Debug.Log(weapons[weaponIndex]);
                weapons.RemoveAt(weaponIndex);
            }
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            for(int i = 0; i < weapons.Count; i++)
            {
                Debug.Log(weapons[i]);
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            NextWeapon();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PreviousWeapon();
        }
    }

    void NextWeapon()
    {
        weaponIndex++;
        if (weaponIndex >= weapons.Count)
        {
            weaponIndex = 0;
        }
    }

    void PreviousWeapon()
    {
        weaponIndex--;
        if (weaponIndex < 0)
        {
            weaponIndex = weapons.Count - 1;
        }
    }

    public void PickUpWeapon(string weapon)
    {
        //weapons[weaponIndex] = weapon;
        weapons.Add(weapon);
    }
}
