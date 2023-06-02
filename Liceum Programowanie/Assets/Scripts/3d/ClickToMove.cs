using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    [SerializeField] float speed = 5;
    GameObject clickedObject;
    NavMeshAgent agent;
    Attack attack;
    
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        attack = GetComponent<Attack>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleLeftClick();
        }
        if (Input.GetMouseButtonDown(1))
        {
            UseSkill();
        }
        if (clickedObject)
        {
            agent.SetDestination(clickedObject.transform.position);
            if(agent.remainingDistance < attack.attackRange)
            {
                Attack();
            }
        }
    }

    void HandleLeftClick()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mouseRay, out RaycastHit mouseHit))
        {
            int clickedLayer = mouseHit.collider.gameObject.layer;
            if (clickedLayer == LayerMask.NameToLayer("Ground"))
            {
                agent.SetDestination(mouseHit.point);
                clickedObject = null;
            }
            else if(clickedLayer == LayerMask.NameToLayer("Enemy"))
            {
                clickedObject = mouseHit.collider.gameObject;
                float distanceToTarget = Vector3.Distance(transform.position, mouseHit.collider.transform.position);
                if(distanceToTarget < attack.attackRange)
                {
                    Attack();
                }
                else
                {
                    agent.SetDestination(clickedObject.transform.position);
                }
            }
        }
    }
    void Attack()
    {
        attack.AttackTarget(clickedObject.GetComponent<Health>());
        clickedObject = null;
    }

    void UseSkill()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mouseRay, out RaycastHit mouseHit))
        {
            Vector3 direction = mouseHit.point - transform.position;
            direction.y = 0;
            transform.rotation = Quaternion.LookRotation(direction);
            Shoot();
        }
    }

    void Shoot()
    {
        Rigidbody bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.AddForce(bullet.transform.forward * 10, ForceMode.Impulse);
    }
    [SerializeField] Rigidbody bulletPrefab;
}
