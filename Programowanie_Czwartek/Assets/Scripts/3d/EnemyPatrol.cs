using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] List<Transform> patrolPoints;
    private Vector3 randomDestination; // losowy punkt docelowy
    [SerializeField] float minDistance = 5f; // minimalna odleg³oœæ do osi¹gniêcia punktu docelowego
    [SerializeField] float maxDistance = 15f; // maksymalna odleg³oœæ do osi¹gniêcia punktu docelowego
    [SerializeField] float updateInterval = 5f; // interwa³ aktualizacji losowego celu
    [SerializeField] float chaseDistance = 10f; // odleg³oœæ, po której obiekt zacznie goniæ gracza
    private float timer; // timer dla interwa³u aktualizacji
    private Transform playerTransform; // transform gracza
    private bool isChasing = false;
    [SerializeField] float waitTime = 2f; // czas oczekiwania na losowej pozycji
    private bool isWaiting = false; // flaga, czy obiekt czeka
    private float waitTimer; // timer dla oczekiwania na losowej pozycji

    int patrolPointIndex = 0;

    void Start()
    {
     //   agent = GetComponent<NavMeshAgent>();
       // agent.SetDestination(patrolPoints[0].position);
        agent = GetComponent<NavMeshAgent>(); // pobranie komponentu NavMeshAgent
        timer = updateInterval; // ustawienie pocz¹tkowego czasu
        SetRandomDestination(); // ustawienie pocz¹tkowego losowego celu
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // znalezienie transformacji gracza

    }

    void Update()
    {
        // if(agent.remainingDistance < agent.stoppingDistance)
        //{
        //    //patrolPointIndex++;
        //    //if(patrolPointIndex >= patrolPoints.Count)
        //    //{
        //    //    patrolPointIndex = 0;
        //    //}
        //    patrolPointIndex = (patrolPointIndex + 1) % patrolPoints.Count;
        //    agent.SetDestination(patrolPoints[patrolPointIndex].position);
        //}
        timer -= Time.deltaTime; // odliczanie czasu

        // jeœli czas do aktualizacji losowego celu min¹³, ustaw nowy losowy cel
        if (timer <= 0f && !isChasing && !isWaiting)
        {
            SetRandomDestination();
            timer = updateInterval;
        }

        // sprawdzenie odleg³oœci do gracza
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        if (distanceToPlayer <= chaseDistance)
        {
            isChasing = true;
            agent.SetDestination(playerTransform.position); // ustawienie celu na pozycjê gracza
        }
        else
        {
            isChasing = false;
        }

        // sprawdzanie, czy obiekt osi¹gn¹³ cel
        if (!isChasing && !isWaiting && Vector3.Distance(transform.position, randomDestination) <= minDistance)
        {
            isWaiting = true;
            waitTimer = waitTime;
        }

        // odliczanie czasu oczekiwania
        if (isWaiting)
        {
            waitTimer -= Time.deltaTime;
            if (waitTimer <= 0f)
            {
                isWaiting = false;
                SetRandomDestination(); // ustawienie nowego losowego celu
            }
        }
    }
    // ustawianie losowego celu na planszy
    private void SetRandomDestination()
    {
        // generowanie losowego punktu wokó³ obecnej pozycji
        Vector3 randomDirection = Random.insideUnitSphere * Random.Range(minDistance, maxDistance);
        randomDirection += transform.position;
        NavMeshHit navHit;

        // znajdowanie najbli¿szego punktu na NavMesh
        NavMesh.SamplePosition(randomDirection, out navHit, maxDistance, NavMesh.AllAreas);

        randomDestination = navHit.position; // ustawienie nowego celu
        agent.SetDestination(randomDestination); // ustawienie celu dla NavMeshAgent
    }
}
