using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.InputSystem;
using System;
public class Grid1 : MonoBehaviour
{
    #region Variables
    [SerializeField]private GameObject[,] blocksArray;
    [SerializeField][Foldout("Bloki")][ShowAssetPreview] private Sprite blockSprite;
    [SerializeField][Foldout("Bloki")] int size;
    [SerializeField][Foldout("Spawner")]int gridX,gridY;
    [SerializeField][Foldout("Spawner")]float gridOffset;
    [SerializeField][Foldout("Spawner")]private Vector2 gridOrgin = Vector2.zero;
    LECoding leCoding;
    private InputAction move;
    Vector2 lastKnownLocation=new Vector2(0,0);
    Vector2 movement;
    #endregion
    #region InputInit
    private void Awake()
    {
        leCoding = new LECoding();
        blocksArray = new GameObject[gridX, gridY];
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
        //oszczêdza miejsce w kodzie
        switch (param)
        {
            case "x":
                return Mathf.FloorToInt(lastKnownLocation.x);
            case "y":
                return Mathf.FloorToInt(lastKnownLocation.y);
            default:
                return 0;
        }

        //if (param == "x")
        //{
        //    return Mathf.FloorToInt(lastKnownLocation.x);
        //}
        //if (param == "y")
        //{
        //    return Mathf.FloorToInt(lastKnownLocation.y);
        //}
        //else
        //{
        //    return 0;
        //}
    }
    void Start()
    {
        SpawnGrid();
        //for 1 block to select
        blocksArray[LastKnowLocation("x"),LastKnowLocation("y")].GetComponent<SpriteRenderer>().material.color=new Color(0,0,255);
    }
    void SpawnGrid()
    {
        for (int x = 0; x < gridX; x++)
        {
            for (int y = 0; y < gridY; y++)
            {
                Vector2 spawnPosition = new Vector2(x * gridOffset, y * gridOffset) + gridOrgin;
                SpawnCubeFuckPrefabs(x, y, spawnPosition);
            }

        }
    }
    //Kocham unity jak wiszenie na ¿yrandolu
    void SpawnCubeFuckPrefabs(int x, int y,Vector2 spawnPosition)
    {
        GameObject cube = new GameObject($@"x:{x}y:{y}",typeof(SpriteRenderer));
        cube.GetComponent<SpriteRenderer>().sprite = blockSprite;
        cube.transform.position=spawnPosition;
        blocksArray.SetValue(cube, x, y);
    }
    #endregion
    #region Movement
    void GridMovement()
    {
        if (movement.x != 0 || movement.y != 0)
        {
            //looping
            switch (Mathf.FloorToInt((movement.x + lastKnownLocation.x))<0, gridX-1 < Mathf.FloorToInt((movement.x + lastKnownLocation.x)), gridY-1 < Mathf.FloorToInt((movement.y + lastKnownLocation.y)),0 > Mathf.FloorToInt((movement.y + lastKnownLocation.y)))
            {
                //kwadrat wychodzi gór¹
                case (true,false,false,false):
                    blocksArray[LastKnowLocation("x"), LastKnowLocation("y")].GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255);
                    blocksArray[gridX-1, LastKnowLocation("y") + Mathf.FloorToInt(movement.y)].GetComponent<SpriteRenderer>().material.color = new Color(0, 0, 255);
                    lastKnownLocation = new Vector2(gridX-1, lastKnownLocation.y);
                    break;
                //kwadrat wychodzi gór¹
                case (false,true,false,false):
                    blocksArray[LastKnowLocation("x"), LastKnowLocation("y")].GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255);
                    blocksArray[0, LastKnowLocation("y") + Mathf.FloorToInt(movement.y)].GetComponent<SpriteRenderer>().material.color = new Color(0, 0, 255);
                    lastKnownLocation = new Vector2(0, lastKnownLocation.y);
                    break;
                //kwadrat wychodzi z lewej
                case (false,false,true,false):
                    blocksArray[LastKnowLocation("x"), LastKnowLocation("y")].GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255);
                    blocksArray[LastKnowLocation("x") + Mathf.FloorToInt(movement.x), 0].GetComponent<SpriteRenderer>().material.color = new Color(0, 0, 255);
                    lastKnownLocation = new Vector2(lastKnownLocation.x, 0);
                    break;
                //kwadrat wychodzi z prawej
                case (false,false,false,true):
                    blocksArray[LastKnowLocation("x"), LastKnowLocation("y")].GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255);
                    blocksArray[LastKnowLocation("x") + Mathf.FloorToInt(movement.x), gridY - 1].GetComponent<SpriteRenderer>().material.color = new Color(0, 0, 255);
                    lastKnownLocation = new Vector2(lastKnownLocation.x, gridY - 1);
                    break;
                //wszystko ok
                default:
                    blocksArray[LastKnowLocation("x"), LastKnowLocation("y")].GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255);
                    blocksArray[LastKnowLocation("x") + Mathf.FloorToInt(movement.x), LastKnowLocation("y") + Mathf.FloorToInt(movement.y)].GetComponent<SpriteRenderer>().material.color = new Color(0, 0, 255);
                    lastKnownLocation += movement;
                    break;

            }
                //blocksArray[LastKnowLocation("x"),LastKnowLocation("y")].GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255);
                //blocksArray[LastKnowLocation("x")+Mathf.FloorToInt(movement.x),LastKnowLocation("y")+Mathf.FloorToInt(movement.y)].GetComponent<SpriteRenderer>().material.color = new Color(0, 0, 255);
                //lastKnownLocation += movement;            
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //zczytywanie movementu
        movement = move.ReadValue<Vector2>().normalized;
        //Debug.Log(movemnt);
        GridMovement();
    }
    #endregion
}
