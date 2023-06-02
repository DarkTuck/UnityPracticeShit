using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] float range;
    [SerializeField] LineRenderer line;

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, range);
        line.SetPosition(0, transform.position);
        if (hit.collider)
        {
            line.SetPosition(1, hit.point);
        }
        else
        {
            line.SetPosition(1, transform.position + transform.right * range);
        }
    }

    //private void OnDrawGizmos()
    //{
    //    RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, range);
    //    Gizmos.color = Color.red;
    //    if(hit.collider)
    //    {
    //        Gizmos.DrawLine(transform.position, hit.point);
    //        Gizmos.DrawSphere(hit.point, 0.2f);

    //        Vector2 reflected = Vector2.Reflect(transform.right, hit.normal);
    //        float remainingRange = range - hit.distance;
    //        Gizmos.DrawRay(hit.point, reflected* remainingRange);
    //        Gizmos.color = Color.green;
    //        Gizmos.DrawRay(hit.point, hit.normal * 5);
    //    }
    //    else
    //    {
    //        Gizmos.DrawLine(transform.position, transform.position + transform.right * range);
    //    }
    //}
}
