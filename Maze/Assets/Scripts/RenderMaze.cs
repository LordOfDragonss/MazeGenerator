using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderMaze : MonoBehaviour
{
    [SerializeField] MazeGenerator mazeGenerator;
    [SerializeField] GameObject cellPrefabObject;

    public float cellSize = 1f;

    private void Start()
    {
        Cell[,] maze = mazeGenerator.GetMaze();

        for (int x = 0; x < mazeGenerator.mazeWidth; x++)
        {
            for (int y = 0; y < mazeGenerator.mazeHeight; y++)
            {
                //Instantiate a new cell based on given position and size
                GameObject newCell = Instantiate(cellPrefabObject, new Vector3((float)x * cellSize, 0f, (float)y * cellSize), Quaternion.identity, transform);
                //Scale the genereted cell based on cellSize
                newCell.gameObject.transform.localScale = new Vector3(newCell.gameObject.transform.localScale.x * cellSize, newCell.gameObject.transform.localScale.y * cellSize, newCell.gameObject.transform.localScale.z * cellSize); // code to scale the cells based on cellsize

                //get the cellObject component to use it in further code
                CellObject cell = newCell.GetComponent<CellObject>();

                //Check the walls to display
                bool top = maze[x, y].topWall;
                bool left = maze[x, y].leftWall;

                bool right = false;
                bool bottom = false;
                if(x == mazeGenerator.mazeWidth - 1) right = true;
                if(y == 0) bottom = true;
                cell.Init(top,bottom,left,right);
            }
        }
    }
}
