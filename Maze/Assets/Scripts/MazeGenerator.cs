using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Direction
{
    Up,
    Down,
    Left,
    Right
}

public class MazeGenerator : MonoBehaviour
{
    public Cell currentCell;
    public int mazeWidth, mazeHeight;
    Cell[,] maze;
    public Cell[,] GetMaze()
    {
        maze = new Cell[mazeWidth, mazeHeight];
        for (int x = 0; x < mazeWidth; x++)
        {
            for (int y = 0; y < mazeHeight; y++)
            {
                maze[x, y] = new Cell(x, y);
            }
        }
        return maze;
    }
}

public class Cell
{
    public int x, y;
    public bool gotVisited;
    public bool topWall, leftWall;
    public Cell(int xpos, int ypos)
    {
        x = xpos;
        y = ypos;

        gotVisited = false;
        topWall = true;
        leftWall = true;
    }
}
