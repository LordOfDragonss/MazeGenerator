using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        CenterOnMaze();
    }

    [Header("Center On Maze")]
    [SerializeField] Camera cam;
    [SerializeField] MazeSettings maze;

    public void CenterOnMaze()
    {

        float mazeWidth = maze.mazeWidth;
        float mazeHeight = maze.mazeHeight;


        // Calculate the field of view based on the maze's dimensions
        float fov = Mathf.Min(100f, 2 * Mathf.Atan(Mathf.Tan(cam.fieldOfView * Mathf.Deg2Rad / 2) * Mathf.Max(mazeWidth / mazeHeight, mazeHeight / mazeWidth)) * Mathf.Rad2Deg);

        float cameraHeight = Mathf.Max(mazeWidth / (2.0f * Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad)), mazeHeight / 2.0f);

        cam.fieldOfView = fov;
        Vector3 cameraPosition = new Vector3(mazeWidth / 2, cameraHeight, mazeHeight / 2);
        cam.gameObject.transform.position = cameraPosition;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
