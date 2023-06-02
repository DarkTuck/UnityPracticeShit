using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhileTest : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1;
    [SerializeField] float moveTime = 1;
    [SerializeField] Transform moveTarget;
    bool isMoving;
    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(MoveInDirection(Vector3.right));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(MoveInDirection(Vector3.left));
        }
    }

    IEnumerator MoveInDirection(Vector3 direction)
    {
        isMoving = true;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = startPosition + direction;
        float moveProgress = 0;
        while (moveProgress < 1)
        {
            moveProgress += Time.deltaTime / moveTime;
            transform.position = Vector3.Lerp(startPosition,
                endPosition,
                moveProgress);
            yield return null;
        }
        isMoving = false;
    }

    IEnumerator MoveToTarget()
    {
        isMoving = true;
        while (transform.position != moveTarget.position)
        {
            //Vector3 direction = moveTarget.position - transform.position;
            //direction.Normalize();
            //transform.Translate(direction * moveSpeed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position,
                moveTarget.position, moveSpeed * Time.deltaTime);
            yield return null;
        }
        isMoving = false;
    }

    IEnumerator LerpToTarget()
    {
        isMoving = true;
        Vector3 startPos = transform.position;
        float moveProgress = 0;
        while(moveProgress<1)
        {
            moveProgress += Time.deltaTime /moveTime;
            transform.position = Vector3.Lerp(startPos,
                moveTarget.position, moveProgress);
            yield return null;
        }
        isMoving = false;
    }

    public float range = 1;

    public Vector3 startPos;
    public Vector3 endPos;
    [Range(0,1)]
    public float t;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(startPos, 0.2f);
        Gizmos.DrawSphere(endPos, 0.2f);
        Gizmos.DrawLine(startPos, endPos);

        Vector3 pos = Vector3.Lerp(startPos, endPos, t);
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(pos, 0.3f);
    }
}
