using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ValueConstraints.ValueControls.Behaviours;

public class ChangeSpeed : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    void FixedUpdate ()
    {

        SmoothWaypoint3DBehaviour comp = GetComponent<SmoothWaypoint3DBehaviour>();

        if (comp.valueControl.maxDelta  <= 1f)
        {
            comp.valueControl.maxDelta = 1f;
        }
    }

    // Update is called once per frame
    public void UpVitesse()
    {

        SmoothWaypoint3DBehaviour comp = GetComponent<SmoothWaypoint3DBehaviour>();

        comp.valueControl.maxDelta += 0.5f;


    }

    public void LowVitesse()
    {

        SmoothWaypoint3DBehaviour comp = GetComponent<SmoothWaypoint3DBehaviour>();

        comp.valueControl.maxDelta -= 4f;


    }
}