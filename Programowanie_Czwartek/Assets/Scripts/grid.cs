using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.InputSystem;
using System;
public class grid : MonoBehaviour
{
    [SerializeField]private GameObject[] blocks;
    [SerializeField][Foldout("Bloki")][ShowAssetPreview] private GameObject block;
    [SerializeField][Foldout("Bloki")] int size;
    [SerializeField][Foldout("Spawner")]int gridX,gridY;
    [SerializeField][Foldout("Spawner")]float gridOffset;
    [SerializeField][Foldout("Spawner")]private Vector2 gridOrgin = Vector2.zero;
    LECoding leCoding;
    private InputAction move;
    int lastKnownLocation=0;
    Vector2 movemnt;
    // Start is called before the first frame update
    #region InputInit
    private void Awake()
    {
        leCoding = new LECoding();
    }
    private void OnEnable()
    {
        move = leCoding.Player.Move;
        leCoding.Player.Enable();
    }
    private void OnDisable()
    {
        leCoding.Player.Disable();
    }
    #endregion
    #region SpawnGrid
    void Start()
    {
        SpawnGrid();
        blocks = GameObject.FindGameObjectsWithTag("block");
        blocks[lastKnownLocation].GetComponent<SpriteRenderer>().material.color=new Color(0,0,255);
    }
    void SpawnGrid()
    {
        for (int x = 0; x < gridX; x++)
        {
            for (int y = 0; y < gridY; y++)
            {
                Vector2 spaawnPosition = new Vector2(x * gridOffset, y * gridOffset) + gridOrgin;
                Instantiate(block, spaawnPosition, Quaternion.identity);
            }

        }
    }
    #endregion
    void GridMovement()
    {
        if (movemnt.x != 0 || movemnt.y != 0)
        {
            blocks[lastKnownLocation].GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255);
            if (movemnt.x < 0 || movemnt.x > 0)
            {
                blocks[lastKnownLocation].GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255);
                blocks[lastKnownLocation+Mathf.FloorToInt(movemnt.x*gridY)].GetComponent<SpriteRenderer>().material.color = new Color(0, 0, 255);
                lastKnownLocation += Mathf.FloorToInt(movemnt.x * gridY);
            }
            if (movemnt.y < 0 || movemnt.y > 0)
            {
                blocks[lastKnownLocation].GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255);
                blocks[lastKnownLocation + (Mathf.FloorToInt(movemnt.y))].GetComponent<SpriteRenderer>().material.color = new Color(0, 0, 255);
                lastKnownLocation += Mathf.FloorToInt(movemnt.y);
            }
            
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        movemnt = move.ReadValue<Vector2>().normalized;
        //Debug.Log(movemnt);
        GridMovement();
    }
}
