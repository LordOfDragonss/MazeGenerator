using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public ObjectiveTracker tracker;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (ButtonEvents.instance.ColorActive)
            {
                other.gameObject.GetComponent<MeshRenderer>().material.color = gameObject.GetComponent<MeshRenderer>().material.color;
            }
            tracker.score++;
            Destroy(this.gameObject);

        }
    }
}
