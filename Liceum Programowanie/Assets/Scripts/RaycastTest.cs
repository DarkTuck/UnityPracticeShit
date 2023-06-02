using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    [SerializeField] LayerMask targetLayer;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float groundRayDistance = 0.6f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Ray ray = new Ray(transform.position, Vector3.down);
            Debug.DrawRay(ray.origin, ray.direction * 5, Color.red, 1);
            RaycastHit2D hitInfo = Physics2D.Raycast(ray.origin, ray.direction, 5, targetLayer);
            if (hitInfo.collider)
            {
                Destroy(hitInfo.collider.gameObject);
            }
        }
    }

    void Jump()
    {
        RaycastHit2D groundHit = Physics2D.Raycast(transform.position,
            Vector3.down, groundRayDistance,groundLayer);

        if(groundHit.collider)
        {
            rb.velocity = Vector3.up * 3;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, Vector3.down * groundRayDistance);
    }
    //private void OnDrawGizmos()
    //{
    //    Ray ray = new Ray(transform.position, Vector3.down);
    //    RaycastHit2D hitInfo = Physics2D.Raycast(ray.origin,ray.direction, 5, targetLayer);
    //    if(hitInfo.collider)
    //    {
    //        Gizmos.color = Color.red;
    //        Gizmos.DrawRay(ray.origin, ray.direction * 10);
    //    }
    //    else
    //    {
    //        Gizmos.color = Color.green;
    //        Gizmos.DrawRay(ray.origin, ray.direction * 10);
    //    }
    //}
}
