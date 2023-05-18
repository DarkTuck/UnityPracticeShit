using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletStats 
{
    public int damage = 1;
    [Range(0f,30f)]
    public float bulletSpeed = 10;
}
