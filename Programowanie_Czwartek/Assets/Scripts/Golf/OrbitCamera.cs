using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform arm;
    [SerializeField] float rotationSpeed = 1;
    [SerializeField] float moveSpeed = 3;
    float armRotX, armRotY;

    void Start()
    {
        armRotX = arm.transform.rotation.x;
        armRotY = arm.transform.rotation.y;
    }

    void LateUpdate()
    {
        transform.LookAt(target.position);
        if(target.GetComponent<BallController>().isMoving == false)
        {
            arm.transform.position = Vector3.MoveTowards(arm.transform.position, 
                target.transform.position, moveSpeed * Time.deltaTime);
        }
       
        if(Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            armRotX -= mouseY * rotationSpeed;
            armRotY += mouseX * rotationSpeed;

            arm.transform.rotation = Quaternion.Euler(armRotX, armRotY, 0);
        }
    }
}
