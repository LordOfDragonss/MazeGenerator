using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellObject : MonoBehaviour
{
    [SerializeField] internal GameObject topWall;
    [SerializeField] internal GameObject bottomWall;
    [SerializeField] internal GameObject leftWall;
    [SerializeField] internal GameObject rightWall;
    public void Init(bool top,bool bottom, bool left, bool right)
    {
        topWall.SetActive(top);
        bottomWall.SetActive(bottom);
        leftWall.SetActive(left);
        rightWall.SetActive(right); 
    }
}
