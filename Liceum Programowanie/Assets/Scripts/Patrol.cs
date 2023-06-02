using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed = 2;
    public Transform[] points;
    private Transform currentPoint;
    int currentIndex;

    void Start()
    {
        currentPoint = points[0];
    }

    void Update()
    {
        //IdŸ do obecnego punktu
        //Vector3 toCurrentPoint = currentPoint.position - transform.position;
        //transform.Translate(toCurrentPoint.normalized * Time.deltaTime * speed);

        transform.position = Vector3.MoveTowards
            (transform.position, currentPoint.position, speed * Time.deltaTime);
        //jak dojdziemy, to ustawiamy obecny punkt na ten drugi
        //float disctanceToCurrent = toCurrentPoint.magnitude;
        float disctanceToCurrent = Vector3.Distance
            (transform.position, currentPoint.position);

        if (disctanceToCurrent == 0f)
        {
            SetNextPoint();
        }
    }

    void SetNextPoint()
    {
        currentIndex++;
        if(currentIndex >= points.Length)
        {
            currentIndex = 0;
        }
        currentPoint = points[currentIndex];
    }
}
