using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictorySequence : MonoBehaviour
{
    [SerializeField] ObjectiveTracker tracker;
    [SerializeField] GameObject VictoryScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(tracker.score == tracker.maxScore && tracker.score != 0)
        {
            VictoryScreen.SetActive(true);
        } 
    }
}
