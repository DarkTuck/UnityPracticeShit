using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.InputSystem;
using System;
public class Grid1 : MonoBehaviour
{
    #region Variables
    public GameObject[,] blocks;
    [SerializeField][Foldout("Bloki")][ShowAssetPreview] private GameObject block;
    [SerializeField][Foldout("Bloki")] int size;
    [SerializeField][Foldout("Spawner")]int gridX,gridY;
    [SerializeField][Foldout("Spawner")]float gridOffset;
    [SerializeField][Foldout("Spawner")]private Vector2 gridOrgin = Vector2.zero;
    LECoding leCoding;
    private InputAction move;
    Vector2 lastKnownLocation=new Vector2(0,0);
    Vector2 movemnt;
    #endregion
    #region InputInit
    private void Awake()
    {
        leCoding = new LECoding();
        blocks = new GameObject[gridX, gridY];
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
    int LastKnowLocation(string param)
    {
        if (param == "x")
        {
            return Mathf.FloorToInt(lastKnownLocation.x);
        }
        if (param == "y")
        {
            return Mathf.FloorToInt(lastKnownLocation.y);
        }
        else
        {
            return 0;
        }
    }
    void Start()
    {
        SpawnGrid();
        //blocks = GameObject.FindGameObjectsWithTag("block");
        blocks[LastKnowLocation("x"),LastKnowLocation("y")].GetComponent<SpriteRenderer>().material.color=new Color(0,0,255);
    }
    void SpawnGrid()
    {
        for (int x = 0; x < gridX; x++)
        {
            for (int y = 0; y < gridY; y++)
            {
                GameObject spawnBlock = block;
                Vector2 spaawnPosition = new Vector2(x * gridOffset, y * gridOffset) + gridOrgin;
                block=Instantiate(block, spaawnPosition, Quaternion.identity);
                blocks.SetValue(spawnBlock,x,y);
            }

        }
    }
    #endregion
    #region Movement
    void GridMovement()
    {
        if (movemnt.x != 0 || movemnt.y != 0)
        {
                blocks[LastKnowLocation("x"),LastKnowLocation("y")].GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255);
                blocks[LastKnowLocation("x")+Mathf.FloorToInt(movemnt.x),LastKnowLocation("y")+Mathf.FloorToInt(movemnt.y)].GetComponent<SpriteRenderer>().material.color = new Color(0, 0, 255);
                lastKnownLocation += movemnt;            
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        movemnt = move.ReadValue<Vector2>().normalized;
        //Debug.Log(movemnt);
        GridMovement();
    }
    #endregion
}
