using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvents : MonoBehaviour
{
    [SerializeField] GameObject MazePrefab;
    [SerializeField] GameObject BasicMazePrefab;
    [SerializeField] GameObject ColorMazePrefab;
    bool ColorActive;
    GameObject currentMaze;
    public void GenerateMaze()
    {
        if (currentMaze == null)
            currentMaze = Instantiate(MazePrefab);
        else
        {
            Destroy(currentMaze);
            currentMaze = Instantiate(MazePrefab);
        }
    }

    public void ColorMaze()
    {
        ColorActive = ColorActive ? false : true;
        if (ColorActive)
        {
            MazePrefab = ColorMazePrefab;
        }
        else
        {
            MazePrefab = BasicMazePrefab;
        }
        GenerateMaze();
    }

}
