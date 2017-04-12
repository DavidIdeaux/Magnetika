/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveJuicy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		float coef = (Time.time - timer) / timeOfTransition;

		if (reverse) {
			transform.position = positionB - easingFunction (coef) * CapsuleDirection2D;
		} else 
		{

			transform.position = positionA + easingFunction.Evaluate (coef) * CapsuleDirection2D;
		}
	}
}*/
