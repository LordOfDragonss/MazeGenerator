using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvents : MonoBehaviour
{
    [SerializeField] CameraControls cameraCont;
    [SerializeField] GameObject MazePrefab;
    [SerializeField] GameObject BasicMazePrefab;
    [SerializeField] GameObject ColorMazePrefab;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject objectivePrefab;

    [SerializeField] int ObjectiveAmnt;
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
        GameObject player = Instantiate(playerPrefab);
        PlayerMovement playermoves = player.GetComponent<PlayerMovement>();
        playermoves.maze = currentMaze.GetComponent<RenderMaze>();
        SpawnObjectives();

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
    public void SpawnObjectives()
    {
        for (int i = 0; i < ObjectiveAmnt; i++)
        {
            Instantiate(objectivePrefab, new Vector3(Random.Range(0, settings.mazeWidth), 0, Random.Range(0, settings.mazeHeight)), Quaternion.identity);
        }
    }
}
