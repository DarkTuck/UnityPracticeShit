using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class EnemyMove : MonoBehaviour
{
    [SerializeField][Required] float speed, distance;
    Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = startPosition + new Vector3(Mathf.Sin(Time.time * speed) * distance, 0, 0);
        transform.position = newPosition;
    }
}
