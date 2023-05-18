using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    [SerializeField] float speed = 5;
    NavMeshAgent agent;
    Vector3 moveTarget;
    
    private void Start()
    {
        moveTarget = transform.position;
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveToMouse();
        }
    }

    void MoveToMouse()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mouseRay, out RaycastHit mouseHit))
        {
            agent.SetDestination(mouseHit.point);
        }
    }

}
