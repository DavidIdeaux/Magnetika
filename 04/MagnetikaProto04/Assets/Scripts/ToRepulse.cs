using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToRepulse : MonoBehaviour
{

    Magnetism repulse;

    // Use this for initialization
    void Start()
    {

        repulse = GetComponent<Magnetism>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        repulse.Repulsion();
        repulse.DistanceForce();
    }
}
