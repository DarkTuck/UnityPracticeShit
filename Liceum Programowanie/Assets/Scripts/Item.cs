using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string name;
    public string description;
    public int price;

    public Item()
    {
    }

    public Item (string _name)
    {
        name = _name;
        description = _name;
        price = 100;
    }

    public Item(string _name, string _descripion, int _price)
    {
        name = _name;
        description = _descripion;
        price = _price;
    }

    public void DebugDescription()
    {
        Debug.Log(description);
    }
}
