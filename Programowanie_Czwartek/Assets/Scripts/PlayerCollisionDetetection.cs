using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetetection : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with " + collision.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Debug.Log("Triggered with "+ otherCollider.gameObject.name);
        if(otherCollider.CompareTag("Collectable"))
        {
            Destroy(otherCollider.gameObject);
            //FindObjectOfType<ObjectSpawner>().SpawnObject();
        }

        ColrSetter colrSetter = otherCollider.GetComponent<ColrSetter>();
        if(colrSetter != null)
        {
            colrSetter.SwitchColor();
        }  
    }
}
