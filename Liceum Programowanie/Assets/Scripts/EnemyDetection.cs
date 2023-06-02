using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField] Transform[] playerSpots;

    [SerializeField] LayerMask obstacleMask;

    [SerializeField] Transform eyes;
    void Update()
    {
        bool canSee = false;
        for (int i = 0; i < playerSpots.Length; i++)
        {
            if (CanSeeTarget(playerSpots[i]))
            {
                Debug.Log(playerSpots[i].gameObject.name);
                canSee = true;
                break;
            }
        }

        Debug.Log(canSee);
    }
   
    bool CanSeeTarget(Transform target)
    {
        Vector3 toPlayer = target.position - eyes.position;
        RaycastHit2D hit = Physics2D.Raycast(eyes.position, toPlayer, toPlayer.magnitude, obstacleMask);
        if (!hit.collider)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
