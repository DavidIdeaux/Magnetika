/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorJuicy : MonoBehaviour {

	public AnimationCurve easingFunction;
	public Color colorA;
	public Color colorB;
	float timer;
	//float x =  (Time.time - timer) / timeOfTransition;

	// Use this for initialization
	void Start () {
		timer = Time.time;
		renderer = GetComponent<Renderer>();
		
	}
	
	// Update is called once per frame
	void Update () {

		float coef =  (Time.time - timer) / timeOfTransition;
		renderer.material.color = Color.LerpUnclamped(colorA, colorB, easingFunction.Evaluate(coef));
		
	}
}*/
