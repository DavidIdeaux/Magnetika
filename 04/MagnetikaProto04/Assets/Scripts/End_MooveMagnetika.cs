using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_MooveMagnetika : MonoBehaviour {

	Moove_Magnetika ScriptMoove_Magnetika;  

	public GameObject _TriggerEnter; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter (Collider col) {

		if (col.gameObject.tag == "Player") {


			ScriptMoove_Magnetika = _TriggerEnter.GetComponent<Moove_Magnetika> ();

			ScriptMoove_Magnetika.END = true; 

		}

	}
}

