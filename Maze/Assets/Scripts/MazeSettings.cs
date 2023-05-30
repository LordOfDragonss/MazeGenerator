using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MazeSettings : MonoBehaviour
{
    public int mazeWidth;
    public int mazeHeight;

    [SerializeField] TMP_InputField widthField;
    [SerializeField] TMP_InputField heightField;

    public int defaultWidth = 20;
    public int defaultHeight = 20;

    // Start is called before the first frame update
    void Start()
    {
        if (mazeHeight == 0)
            mazeHeight = defaultHeight;
        if (mazeWidth == 0)
            mazeWidth = defaultWidth;
    }

    // Update is called once per frame
    void Update()
    {
        mazeWidth = int.Parse(widthField.text);
        mazeHeight = int.Parse(heightField.text);
    }
}
