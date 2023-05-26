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
    [SerializeField] MazeGenerator maze;

    public void CenterOnMaze()
    {
        //center camera based on the mazes center currently uses the mazewidth for the height of the camera to display everything aslong as both mazeheight and mazewidth are equal
        cam.gameObject.transform.position = new Vector3(transform.position.x + maze.mazeWidth / 2, maze.mazeWidth, transform.position.z + maze.mazeHeight / 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
