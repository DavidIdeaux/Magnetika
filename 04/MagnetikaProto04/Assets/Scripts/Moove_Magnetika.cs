using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moove_Magnetika : MonoBehaviour {

	public GameObject _Emplacement; 

	public GameObject Magnetika; 

	public float speed = 0.02f; 

	public bool Enclenchement; 
	public bool END; 

	private Vector3 StartPos;

	private Vector3 EndPos; 

	private float _Distance; 



	ToAttract ScriptToAttract;  

	ToRepulse ScriptToRepulse; 



	void Start() {
		Enclenchement = false; 


	}







	void Update () {

		if (Enclenchement == true) {

			StartPos = Magnetika.transform.position;

			EndPos = _Emplacement.transform.position; 
			//Magnetika.transform.Translate (Vector3.Distance (StartPos, EndPos) * _Distance * Time.deltaTime);
			Magnetika.transform.position = Vector3.Lerp (StartPos, EndPos, speed * Time.time);


				

			Magnetika.GetComponent<ToAttract> ().enabled = true; 

			//ScriptToRepulse = GetComponent<ToRepulse>();

			//Debug.Log ("POUET");


		

		if (Enclenchement == false) {


				Magnetika.GetComponent<ToAttract> ().enabled = false; 
		

			}

			if (END == true) {

				Enclenchement = false; 
				Magnetika.GetComponent<ToAttract> ().enabled = false; 
				
			}
		}
	}



	void OnTriggerEnter ( Collider col) {

		if (col.gameObject.tag == "Player") {

			Enclenchement = true;
			END = false;
		}

	}



}
