using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
    [SerializeField] Vector2Int playerCellPosition;
    public GameObject player;
    public RenderMaze maze;
    public int Movementspeed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        playerCellPosition = new Vector2Int((int)transform.position.x, (int)transform.position.z);
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (ButtonEvents.instance.ColorActive)
            {
                if (maze.cells[playerCellPosition.x, playerCellPosition.y+1].bottomWall.activeSelf)
                {
                    if (CheckColor(maze.cells[playerCellPosition.x, playerCellPosition.y+1].bottomWall, player.gameObject))
                    {
                        MoveBasedOnCell(Direction.Up);
                    }
                }
                else
                {
                    MoveBasedOnCell(Direction.Up);
                }
            }
            else
            {
                MoveBasedOnCell(Direction.Up);
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (ButtonEvents.instance.ColorActive)
            {
                if (maze.cells[playerCellPosition.x, playerCellPosition.y-1].topWall.activeSelf)
                {
                    if (CheckColor(maze.cells[playerCellPosition.x, playerCellPosition.y-1].topWall, player.gameObject))
                    {
                        MoveBasedOnCell(Direction.Down);
                    }
                }
                else
                {
                    MoveBasedOnCell(Direction.Down);
                }
            }
            else
            {
                MoveBasedOnCell(Direction.Down);
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (ButtonEvents.instance.ColorActive)
            {
                if (maze.cells[playerCellPosition.x+1, playerCellPosition.y].rightWall.activeSelf)
                {
                    if (CheckColor(maze.cells[playerCellPosition.x+1, playerCellPosition.y].rightWall, player.gameObject))
                    {
                        MoveBasedOnCell(Direction.Down);
                    }
                }
                else
                {
                    MoveBasedOnCell(Direction.Left);
                }
            }
            else
            {
                MoveBasedOnCell(Direction.Left);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (ButtonEvents.instance.ColorActive)
            {
                if (maze.cells[playerCellPosition.x-1, playerCellPosition.y].leftWall.activeSelf)
                {
                    if (CheckColor(maze.cells[playerCellPosition.x-1, playerCellPosition.y].leftWall, player.gameObject))
                    {
                        MoveBasedOnCell(Direction.Down);
                    }
                }
                else
                {
                    MoveBasedOnCell(Direction.Right);
                }
            }
            else
            {
                MoveBasedOnCell(Direction.Right);
            }
        }
    }

    void MoveBasedOnCell(Direction direction)
    {
        //set the players cell position based on the players current transform position
        switch (direction)
        {
            case Direction.Up:
                //check if the topwall is open on the current cell
                if (!maze.cells[playerCellPosition.x, playerCellPosition.y].topWall.activeSelf)
                    player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 1);//move upwards
                break;
            case Direction.Down:
                //check if the bottomwall is open on the current cell and the top wall is open on the cell below
                if (!maze.cells[playerCellPosition.x, playerCellPosition.y].bottomWall.activeSelf && !maze.cells[playerCellPosition.x, playerCellPosition.y - 1].topWall.activeSelf)
                    player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 1);//move downwards
                break;
            case Direction.Left:
                //check if the leftwall is open on the current cell
                if (!maze.cells[playerCellPosition.x, playerCellPosition.y].leftWall.activeSelf)
                    player.transform.position = new Vector3(player.transform.position.x - 1, player.transform.position.y, player.transform.position.z);//move to the left
                break;
            case Direction.Right:
                //check if the rightwall is open on the current cell and the left wall is open on the cell to the right
                if (!maze.cells[playerCellPosition.x, playerCellPosition.y].rightWall.activeSelf && !maze.cells[playerCellPosition.x + 1, playerCellPosition.y].leftWall.activeSelf)
                    player.transform.position = new Vector3(player.transform.position.x + 1, player.transform.position.y, player.transform.position.z);//move to the right
                break;
        }
    }

    bool CheckColor(GameObject firstObject, GameObject secondObject)
    {

        if (firstObject.gameObject.GetComponent<MeshRenderer>().material.color == secondObject.gameObject.GetComponent<MeshRenderer>().material.color)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
