using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Attack), typeof(Health))]
public class EnemyAI : MonoBehaviour
{
    [Header("Wandering")]
    [SerializeField] Transform centerPoint; //Punk wokó³ którego ma chodziæ
    [SerializeField] float maxWanderDistance = 5;
    [SerializeField] float wanderSpeed = 2;

    [Header("Chasing")]
    [SerializeField] Transform player;
    [SerializeField] float chaseSpeed = 4;
    [SerializeField] float chaseStartDistance = 5;
    [SerializeField] float chaseStopDistance = 6;

    [Header("Waiting")]
    [SerializeField] float waitTime = 2;

    [Header("Attacking")]
    [SerializeField] Attack attack;

    NavMeshAgent agent;
    float waitTimer;

    [SerializeField]  EnemyState currentState = EnemyState.Wait;

    enum EnemyState
    {
        Wander,
        Wait,
        Chase,
        Attack
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GoToRandomPoint();
    }

    void Update()
    {
        UpdateState();
    }

    void UpdateState()
    {
        switch (currentState)
        {
            case EnemyState.Wander:
                Wander();
                break;
            case EnemyState.Wait:
                Wait();
                break;
            case EnemyState.Chase:
                Chase();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            default:
                Debug.LogWarning("uninplemented state");
                break;
        }
    }

    void SwitchState(EnemyState nextState)
    {
        OnStateExit(currentState);
        currentState = nextState;
        OnStateEnter(currentState);
    }
    
    void OnStateExit(EnemyState state)
    {
        switch (state)
        {
            case EnemyState.Wander:
                break;
            case EnemyState.Wait:
                break;
            case EnemyState.Chase:
                break;
            case EnemyState.Attack:
                break;
            default:
                break;
        }
    }

    void OnStateEnter(EnemyState state)
    {
        switch (state)
        {
            case EnemyState.Wander:
                agent.speed = wanderSpeed;
                agent.isStopped = false;
                GoToRandomPoint();
                break;
            case EnemyState.Wait:
                agent.isStopped = true;
                waitTimer = waitTime;
                break;
            case EnemyState.Chase:
                agent.isStopped = false;
                agent.speed = chaseSpeed;
                break;
            case EnemyState.Attack:
                agent.isStopped = true;
                break;
            default:
                break;
        }
    }

    private void Chase()
    {
        agent.SetDestination(player.position);
        //Sprawdzamy warunek wyjœcia
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer > chaseStopDistance)
        {
            SwitchState(EnemyState.Wait);
            return;
        }
       if(distanceToPlayer < attack.attackRange)
        {
            SwitchState(EnemyState.Attack);
            return;
        }

    }

    private void Wander()
    {
        //Sprawdzamy warunek przejœcia do innych stanów
        if (Vector3.Distance(transform.position, player.position) < chaseStartDistance)
        {
            SwitchState(EnemyState.Chase);
            return;
        }
        if (ReachedTarget())
        {
            SwitchState(EnemyState.Wait);
        }

    }

    void Wait()
    {
        //Sprawdzamy warunek wyjœcia
        if (Vector3.Distance(transform.position, player.position) < chaseStartDistance)
        {
            SwitchState(EnemyState.Chase);
            return;
        }

        waitTimer -= Time.deltaTime;
        if (waitTimer < 0)
        {
            SwitchState(EnemyState.Wander);
        }
    }

    void Attack()
    {
        if(Vector3.Distance(transform.position, player.position) > attack.attackRange)
        {
            SwitchState(EnemyState.Chase);
        }

        attack.AttackTarget(player.GetComponent<Health>());
    }

    void GoToRandomPoint()
    {
        Vector3 randomPoint = centerPoint.position + new Vector3(
            Random.Range(-maxWanderDistance, maxWanderDistance),
            0,
            Random.Range(-maxWanderDistance, maxWanderDistance)
            );

        agent.SetDestination(randomPoint);
    }

    bool ReachedTarget()
    {
        return agent.remainingDistance < agent.stoppingDistance;
    }
}
