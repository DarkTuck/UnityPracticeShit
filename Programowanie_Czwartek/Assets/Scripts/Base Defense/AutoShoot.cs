using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShoot : MonoBehaviour
{
    [SerializeField] Bullet bulletPrefab;
    [SerializeField] Transform gunEnd;
    [Tooltip("Ile razy strzela co sekundê")]
    [SerializeField] float fireRate = 1; //Ile razy strzela co sekundê
    [SerializeField] BulletStats bulletStats;

    float timer;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Shoot();
            if (fireRate == 0) //¯eby nie dzieliæ przez 0
            {
                return;
            }
            timer = 1 / fireRate;
        }
    }
    void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab, gunEnd.position, gunEnd.rotation);
        bullet.Init(bulletStats);
    }
}
