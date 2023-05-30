using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvents : MonoBehaviour
{
    [SerializeField] CameraControls cameraCont;
    [SerializeField] GameObject MazePrefab;
    [SerializeField] GameObject BasicMazePrefab;
    [SerializeField] GameObject ColorMazePrefab;
    public MazeSettings settings;
    bool ColorActive;
    GameObject currentMaze;
    public void GenerateMaze()
    {
        cameraCont.CenterOnMaze();
        if (currentMaze == null)
        {
            currentMaze = Instantiate(MazePrefab);
            AsignSettings();
        }
        else
        {
            Destroy(currentMaze);
            currentMaze = Instantiate(MazePrefab);
            AsignSettings();
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

    public void AsignSettings()
    {
        if (settings.mazeHeight == 0)
            settings.mazeHeight = settings.defaultHeight;
        if (settings.mazeWidth == 0)
            settings.mazeWidth = settings.defaultWidth;


        MazeGenerator maze = currentMaze.GetComponent<MazeGenerator>();
        maze.mazeWidth = settings.mazeWidth;
        maze.mazeHeight = settings.mazeHeight;
    }
}
