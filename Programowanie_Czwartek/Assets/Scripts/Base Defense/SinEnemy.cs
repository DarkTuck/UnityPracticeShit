using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinEnemy : MonoBehaviour
{
    [SerializeField] float amplitude = 1;
    [SerializeField] float frequency = 1;

    float randomStartOffset;
    float startY;
    void Start()
    {
        startY = transform.position.y;
        randomStartOffset = Random.Range(0, Mathf.PI *2);
    }

    // Update is called once per frame
    void Update()
    {
        float yOffset = Mathf.Sin(Time.time * frequency + randomStartOffset)
            * amplitude;
        transform.position = new Vector2(transform.position.x, startY + yOffset);
    }
}
