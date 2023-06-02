using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsTest : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float force = 5;
    [SerializeField] Camera cam;
    [SerializeField] float explosionRadius = 3;
    [SerializeField] float explosionUpwardModifier = 0;
    [SerializeField] LayerMask pushableLayer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            Ray mouseRay = cam.ScreenPointToRay(mousePos);
            if (Physics.Raycast(mouseRay, out RaycastHit mouseHit))
            {
                Collider[] objectsInRange = Physics.OverlapSphere(mouseHit.point, explosionRadius, pushableLayer);
                foreach(Collider col in objectsInRange)
                {
                    col.attachedRigidbody?.AddExplosionForce(force, mouseHit.point, explosionRadius,
                        explosionUpwardModifier,ForceMode.Impulse);
                }
                //mouseHit.rigidbody?.AddForceAtPosition(mouseRay.direction * force,
                //    mouseHit.point, ForceMode.Impulse);
            }
        }
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * force,ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * force);
        }


        if (Input.GetMouseButton(1))
        {
            Vector3 mousePos = Input.mousePosition;
            Ray mouseRay = cam.ScreenPointToRay(mousePos);
            if (Physics.Raycast(mouseRay, out RaycastHit mouseHit))
            {
                mouseHit.rigidbody?.AddForce(-mouseRay.direction * force, ForceMode.Force);
            }
        }

    }

}
