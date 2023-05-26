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
    List<Direction> directions = new List<Direction>
    {
    Direction.Up, Direction.Down, Direction.Left, Direction.Right
    };

    List<Direction> GetRandomDirections()
    {
        List<Direction> savedDirections = new List<Direction>(directions);

        List<Direction> randomDirections = new List<Direction>();

        while (savedDirections.Count > 0)
        {
            int rnd = Random.Range(0, directions.Count);
            randomDirections.Add(directions[rnd]);
            savedDirections.RemoveAt(rnd);
        }
        return randomDirections;
    }

    bool IsCellValid(int x, int y)
    {
        if (x < 0 || y < 0 || x > mazeWidth - 1 || y > mazeHeight - 1 || maze[x, y].visited)
        {
            return false;
        }
        else return true;

    }

    void CarvePath(int startPosX, int startPosY)
    {
        if (startPosX < 0 || startPosY < 0 || startPosX > mazeWidth - 1 || startPosY > mazeHeight - 1)
        {
            startPosX = 0;
            startPosY = 0;
            Debug.LogWarning("Start Position out of bounds returning to default");

        }


    }
}

public class Cell
{
    public int x, y;
    public bool visited;
    public bool topWall, leftWall;
    public Cell(int xpos, int ypos)
    {
        x = xpos;
        y = ypos;

        visited = false;
        topWall = true;
        leftWall = true;
    }
}
