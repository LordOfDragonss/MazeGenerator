using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveTracker : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreField;
    [SerializeField] TextMeshProUGUI maxField;
    public int score;
    public int maxScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreField.text = score.ToString();
        maxField.text = "/ " + maxScore.ToString();
    }
}
