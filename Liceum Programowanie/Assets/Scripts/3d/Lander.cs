using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lander : MonoBehaviour
{
    [SerializeField] Transform thrusterR, thrusterL;
    [SerializeField] ParticleSystem engineEffectR, engineEffectL;
    [SerializeField] float thrustForce;
    [SerializeField] float customGravityForce = 3;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        rb.AddForce(Vector3.down * customGravityForce);

        if(Input.GetMouseButton(0))
        {
            rb.AddForceAtPosition(transform.up * thrustForce, thrusterL.position);
            engineEffectL.Emit(1);
        }
        if (Input.GetMouseButton(1))
        {
            rb.AddForceAtPosition(transform.up * thrustForce, thrusterR.position);
            engineEffectR.Emit(1);
        }
    }
}
