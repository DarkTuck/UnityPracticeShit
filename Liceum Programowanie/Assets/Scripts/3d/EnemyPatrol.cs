using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] List<Transform> patrolPoints;

    int patrolPointIndex = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(patrolPoints[0].position);
    }

    void Update()
    {
        if(agent.remainingDistance < agent.stoppingDistance)
        {
            GoToNextPatrolPoint();
        }
    }

    void GoToNextPatrolPoint()
    {            
        //patrolPointIndex++;
        //if(patrolPointIndex >= patrolPoints.Count)
        //{
        //    patrolPointIndex = 0;
        //}
        patrolPointIndex = (patrolPointIndex + 1) % patrolPoints.Count;
        agent.SetDestination(patrolPoints[patrolPointIndex].position);
    }
}
