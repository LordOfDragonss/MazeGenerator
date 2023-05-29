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
    public int startX, startY;
    public Vector2Int currentCell;
    public GameObject currentCellIndicator;
    public int mazeWidth, mazeHeight;
    Cell[,] maze;
    private void Update()
    {
        currentCellIndicator.transform.position = new Vector3(currentCell.x, currentCellIndicator.transform.position.y, currentCell.y);
    }
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
        CarvePath(startX, startY);
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
            int rnd = Random.Range(0, savedDirections.Count);
            randomDirections.Add(savedDirections[rnd]);
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

    Vector2Int CheckNeighbours()
    {
        List<Direction> rndDir = GetRandomDirections();

        for(int i = 0; i < rndDir.Count; i++)
        {
            Vector2Int neighbour = currentCell;

            switch (rndDir[i])
            {
                case Direction.Up:
                    neighbour.y++;
                    break;
                case Direction.Down:
                    neighbour.y--;
                    break;
                case Direction.Left:
                    neighbour.x++;
                    break;
                case Direction.Right:
                    neighbour.x--;
                    break;
            }
            if (IsCellValid(neighbour.x,neighbour.y))
            {
                return neighbour;
            }
        }
        return currentCell;
    }

    void RemoveWall (Vector2Int primary, Vector2Int secondary)
    {
        if(primary.x > secondary.x)
        {
            maze[primary.x,primary.y].leftWall = false;
        }else if(primary.x < secondary.x)
        {
            maze[secondary.x, secondary.y].leftWall = false;
        }
        else if (primary.y < secondary.y)
        {
            maze[primary.x, primary.y].topWall = false;
        }
        else if (primary.y > secondary.y)
        {
            maze[secondary.x, secondary.y].topWall = false;
        }

    }

    void CarvePath(int startPosX, int startPosY)
    {
        if (startPosX < 0 || startPosY < 0 || startPosX > mazeWidth - 1 || startPosY > mazeHeight - 1)
        {
            startPosX = 0;
            startPosY = 0;
            Debug.LogWarning("Start Position out of bounds returning to default");

        }

        currentCell = new Vector2Int(startPosX, startPosY);

        List<Vector2Int> path = new List<Vector2Int>();
        bool deadEnd = false;
        while (!deadEnd)
        {
            Vector2Int nextCell = CheckNeighbours();
            if(nextCell == currentCell)
            {
                for(int i = path.Count - 1; i >= 0; i--)
                {
                    currentCell = path[i];
                    path.RemoveAt(i);
                    nextCell = CheckNeighbours();

                    if (nextCell != currentCell) break;
                }
                if(nextCell == currentCell)
                    deadEnd = true;
            }
            else
            {
                RemoveWall(currentCell, nextCell);
                maze[nextCell.x, nextCell.y].visited = true;
                currentCell = nextCell;
                path.Add(currentCell);
            }
        }
    }
}

public class Cell
{
    public int x, y;
    public bool visited;
    public bool topWall, leftWall;
    public Vector2Int position
    {
        get
        {
            return new Vector2Int(x, y);
        }
    }
    public Cell(int xpos, int ypos)
    {
        x = xpos;
        y = ypos;

        visited = false;
        topWall = true;
        leftWall = true;
    }
}
