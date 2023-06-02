using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopTest : MonoBehaviour
{
    public List<GameObject> objects = new List<GameObject>();
    public List<Color> possibleColors;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer[] sprites = FindObjectsOfType<SpriteRenderer>();

        foreach(SpriteRenderer renderer in sprites)
        {
            //ustawiamy ka¿demu obektowi losowy kolor
            renderer.color = possibleColors[Random.Range(0, possibleColors.Count)];
        }


        for(int i = 0; i < 3; i++)
        {
            Debug.Log(i);
        }

        //for(int i = 0; i < objects.Count; i++)
        //{
        //    Destroy(objects[i]);
        //}
        //objects.Clear();
        Debug.Log("End loop");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
