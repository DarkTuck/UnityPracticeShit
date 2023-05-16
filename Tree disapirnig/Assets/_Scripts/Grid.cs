using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System;
public class Grid : MonoBehaviour
{
    #region Variables
    [SerializeField]private GameObject[,] blocksArray;
    //[SerializeField][Foldout("Bloki")][ShowAssetPreview][Required] private Material blockMaterial;
    [SerializeField][Foldout("Bloki")] int size;
    [SerializeField][Foldout("Spawner")]int gridX,gridY;
    [SerializeField][Foldout("Spawner")]float gridOffset;
    [SerializeField][Foldout("Spawner")]private Vector2 gridOrgin = Vector2.zero;
    [SerializeField] [Foldout("Colors")] [Required] Color colorTopLeft, colorTopRight, colorBottomLeft, colorBottomRight;
    [SerializeField][Foldout("Bloki")] private GameObject drzewo;
    #endregion
    #region SpawnGrid

    private void Awake()
    {
        blocksArray = new GameObject[gridX, gridY];
    }
    void Start()
    {
        SpawnGrid();
    }
    void SpawnGrid()
    {
        for (int x = 0; x < gridX; x++)
        {
            for (int y = 0; y < gridY; y++)
            {
                GameObject cube1=drzewo;
                Vector2 spawnPosition = new Vector2(x * gridOffset, y * gridOffset) + gridOrgin;
                //SpawnCubeFuckPrefabs(x, y, spawnPosition);
                Instantiate(cube1);
                cube1.transform.position = new Vector3(spawnPosition.x, 6.18f, spawnPosition.y);

            }

        }
    }
    //Kocham unity jak wiszenie na ¿yrandolu
    void SpawnCubeFuckPrefabs(int x, int y,Vector2 spawnPosition)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.name = $@"x:{x},y:{y}";
        cube.transform.position=spawnPosition;
        blocksArray.SetValue(cube, x, y);
        //ChangeColor(x, y, cube);
    }
    void ChangeColor(int x, int y,GameObject cube)
    {
        float leprX = (float)x / (gridX - 1);
        float leprY = (float)y / (gridY - 1);
        Color color = Color.Lerp(Color.Lerp(colorBottomLeft, colorTopLeft, leprY), Color.Lerp(colorBottomRight, colorTopRight, leprY), leprX);
        cube.GetComponent<MeshRenderer>().material.color = color;
        cube.name += $@" R:{color.r*255f},G:{color.g*255f},B:{color.b*255f}";

    }
    #endregion
}
