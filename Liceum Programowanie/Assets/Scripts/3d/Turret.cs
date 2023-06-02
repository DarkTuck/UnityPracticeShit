using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float rotSpeed = 30;

    [SerializeField]  Vector3 rotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    Quaternion targetRot;
    // Update is called once per frame
    void Update()
    {
        RotToTarget();

    }

    void AddRotation()
    {
        Quaternion additionalRot = Quaternion.Euler(0, rotSpeed * Time.deltaTime, 0);

        transform.rotation *= additionalRot;

    }

    void RotateLeftRight()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            targetRot = Quaternion.Euler(new Vector3(0, 90, 0));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            targetRot = Quaternion.Euler(new Vector3(0, -90, 0));
        }
        transform.rotation = Quaternion.Slerp
          (transform.rotation, targetRot, rotSpeed * Time.deltaTime);
    }

    void RotToTarget()
    {
        Vector3 toTarget = target.position - transform.position;
        toTarget.y = 0;

        Quaternion targetRot = Quaternion.LookRotation(toTarget);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, rotSpeed * Time.deltaTime);
    }

    void RotToTarget2()
    {
        Vector3 toTarget = target.position - transform.position;
        toTarget.y = 0;

        Quaternion diff = Quaternion.FromToRotation(transform.forward, toTarget);
        Quaternion targetRot = transform.rotation * diff;
         transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, rotSpeed * Time.deltaTime);
       
    }
}
