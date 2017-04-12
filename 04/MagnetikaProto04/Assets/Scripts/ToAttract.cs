using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToAttract : MonoBehaviour {

    Magnetism attract;

	// Use this for initialization
	void Start () {

        attract = GetComponent<Magnetism>();


    }
	
	// Update is called once per frame
	void FixedUpdate () {

        attract.Attraction();
        attract.DistanceForce();
	}
}
