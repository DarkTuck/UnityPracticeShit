using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] float rotationSpeed = 1;
    EnemyManager enemyManager;

    private void Start()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
    }

    void Update()
    {
        RotateToClosestEnemy();

    }

    void RotateToClosestEnemy()
    {
        List<Enemy> enemies = enemyManager.activeEnemies;

        float bestDistance = float.MaxValue;
        Transform closestEnemy = null;
        foreach(Enemy enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position,
                enemy.transform.position);

            if(distance < bestDistance)
            {
                closestEnemy = enemy.transform;
                bestDistance = distance;
            }
        }
        if (closestEnemy == null)
            return;

        Vector2 toTarget = closestEnemy.position - transform.position;
        float angleToTarget = Vector2.SignedAngle(transform.up, toTarget);
        
        Quaternion targetRotation = Quaternion.Euler(0, 0,
            transform.rotation.eulerAngles.z + angleToTarget);

        transform.rotation = Quaternion.RotateTowards(transform.rotation,
                            targetRotation, rotationSpeed * Time.deltaTime);
        //transform.up = toTarget;
    }


}
