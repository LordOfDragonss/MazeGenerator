using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MazeSettings : MonoBehaviour
{
    public int mazeWidth;
    public int mazeHeight;
    public int mazeHeightMax = 250;
    public int mazeHeightMin = 10;
    public int mazeWidthMax = 250;
    public int mazeWidthMin = 10;

    public TMP_InputField widthField;
    public TMP_InputField heightField;

     public TMP_Text errorField;

    public int defaultWidth;
    public int defaultHeight;

    // Start is called before the first frame update
    void Start()
    {
        if (mazeHeight == 0)
            mazeHeight = defaultHeight;
        if (mazeWidth == 0)
            mazeWidth = defaultWidth;
        errorField.text = "";
    }

    // Update is called once per frame
    void Update()
    {


    }
}
