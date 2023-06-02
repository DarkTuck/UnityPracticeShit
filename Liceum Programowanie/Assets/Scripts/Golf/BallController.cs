using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] LineRenderer line;

    [SerializeField] float shootForce = 1;
    [SerializeField] float maxAimDistance = 3;

    Rigidbody rb;

    Vector3 mousePos;
    bool isAiming;
    public bool isMoving;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        line.enabled = false;
    }

    void Update()
    {
        isMoving = CheckIsMoving();

        if (isMoving)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            StartAiming();
        }

        if (isAiming)
        {
            UpdateAim();

            if (Input.GetMouseButtonUp(0))
            {
                Shoot();
            }
        }
    }


        bool CheckIsMoving()
        {
            if( rb.velocity.magnitude < 0.1f)
            {
                rb.velocity = Vector3.zero;
                return false;
            }

            return true;
        }
    

    private void StartAiming()
    {
        Ray mouseRay = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mouseRay, out RaycastHit mousHit))
        {
            if (mousHit.collider.gameObject == gameObject)
            {
                isAiming = true;
                line.enabled = true;
                line.SetPosition(0, transform.position);
            }
        }
    }

    private void UpdateAim()
    {
        Ray mouseRay = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mouseRay, out RaycastHit mouseHit))
        {
            mousePos = mouseHit.point;
            mousePos.y = transform.position.y;
            Vector3 toMouse = mousePos - transform.position;
            if(toMouse.magnitude > maxAimDistance)
            {
                mousePos = transform.position + toMouse.normalized * maxAimDistance;
            }
            line.SetPosition(1, mousePos);
        }
    }

    private void Shoot()
    {
        isAiming = false;
        line.enabled = false;
        Vector3 toMouse = mousePos - transform.position;
        rb.AddForce(-toMouse * shootForce, ForceMode.Impulse);
    }
}
