using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvents : MonoBehaviour
{
    [SerializeField] CameraControls cameraCont;
    [SerializeField] GameObject mazePrefab;
    [SerializeField] GameObject basicMazePrefab;
    [SerializeField] GameObject colorMazePrefab;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject objectivePrefab;
    [SerializeField] ObjectiveTracker Otracker;

    List<GameObject> objectives = new List<GameObject>();
    public CameraControls cam;
    [SerializeField] int ObjectiveAmnt;
    public MazeSettings settings;
    bool ColorActive;
    GameObject currentMaze;
    GameObject player;

    public void GenerateMaze()
    {
        cameraCont.CenterOnMaze();
        if (currentMaze == null)
        {
            InstantiateMaze();
        }
        else
        {
            Destroy(currentMaze);
            Destroy(player);
            foreach (GameObject objective in objectives)
            {
                Destroy(objective);
            }
            Otracker.score = 0;
            InstantiateMaze();
        }
    }

    public void InstantiateMaze()
    {

        if (settings.widthField.text != null)
            int.TryParse(settings.widthField.text, out settings.mazeWidth);
        if (settings.heightField.text != null)
            int.TryParse(settings.heightField.text, out settings.mazeHeight);
        if (
            settings.mazeWidth >= settings.mazeWidthMin &&
            settings.mazeHeight >= settings.mazeHeightMin &&
            settings.mazeWidth <= settings.mazeWidthMax &&
            settings.mazeHeight <= settings.mazeHeightMax)
        {
            currentMaze = Instantiate(mazePrefab);
            AsignSettings();
            cam.CenterOnMaze();
            player = Instantiate(playerPrefab,currentMaze.transform);
            PlayerMovement playermoves = player.GetComponent<PlayerMovement>();
            playermoves.maze = currentMaze.GetComponent<RenderMaze>();
            SpawnObjectives();
            settings.errorField.text = "";
        }
        else
        {
            settings.errorField.text = "Invalid height or width please make sure it's between the minimum and maximum height/width value (default 10min 250max)";
        }
    }

    public void ColorMaze()
    {

        ColorActive = ColorActive ? false : true;
        if (ColorActive)
        {
            mazePrefab = colorMazePrefab;
        }
        else
        {
            mazePrefab = basicMazePrefab;
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
        GameObject objectiveroot = new GameObject("Objectives");
        objectiveroot.transform.parent = currentMaze.transform;
        Otracker.maxScore = ObjectiveAmnt;
        for (int i = 0; i < ObjectiveAmnt; i++)
        {
            GameObject objective = Instantiate(objectivePrefab, new Vector3(Random.Range(0, settings.mazeWidth), 0, Random.Range(0, settings.mazeHeight)), Quaternion.identity, objectiveroot.transform);
            objective.GetComponent<Objective>().tracker = Otracker;
            objectives.Add(objective);
        }
    }
}
