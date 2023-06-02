using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGeneratorColor : MazeGenerator
{

    public enum Colors
    {
        Red,
        Green,
        Blue,
        Yellow
    }

    public void GenerateRandomColoredWalls(CellObject cell)
    {
            List<Direction> rndDir = GetRandomDirections();
            for (int i = 0; i < rndDir.Count; i++)
            {
                switch (rndDir[i])
                {
                    case Direction.Up:
                        SetColor((Colors)Random.Range(0,4), cell.topWall);
                        break;
                    case Direction.Down:
                        SetColor((Colors)Random.Range(0, 4), cell.bottomWall);
                        break;
                    case Direction.Left:
                        SetColor((Colors)Random.Range(0, 4), cell.leftWall);
                        break;
                    case Direction.Right:
                        SetColor((Colors)Random.Range(0, 4), cell.rightWall);
                        break;

                }
            }
    }

    public void SetColor(Colors color, GameObject gObject)
    {
        switch (color)
        {
            case Colors.Red:
                gObject.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                break;
            case Colors.Green:
                gObject.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                break;
            case Colors.Blue:
                gObject.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
                break;
            case Colors.Yellow:
                gObject.gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
                break;
            default:
                gObject.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
                break;
        }
    }



}
