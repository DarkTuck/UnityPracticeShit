using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public Item[] items;
    // Start is called before the first frame update
    void Start()
    {
        Item potion = new Item("Health Potion", "Restores HP", 10);
        potion.DebugDescription();

        Item sword = new Item("Sword");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
