using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictorySequence : MonoBehaviour
{
    [SerializeField] ObjectiveTracker tracker;
    [SerializeField] GameObject victoryScreen;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (tracker.score != 0)
        {
            if (tracker.score == tracker.maxScore)
            {
                victoryScreen.SetActive(true);
            }
        }
        else
        {
            victoryScreen.SetActive(false);
        }

    }
}
