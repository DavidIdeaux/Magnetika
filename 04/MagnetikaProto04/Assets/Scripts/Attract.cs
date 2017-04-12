/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attract : MonoBehaviour {
    public Transform player;
    public Transform module;
    float speed = 10f;
    //speed = 5f si influencé par les modules sinon speed = 10f 
    float distance;
    float distanceForce;
    //float v1;
    //float v2;
    //float v3;
    
    //Detecte si l'entité est à l'intérieur du collider d'un module
    //bool inCol = false;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Attraction();
        DistanceForce();

        //Debug.Log("distanceForce " + distanceForce);
        //Debug.Log("distance " + distance);

    }

    //DistanceForce est une fonction qui recupere la distance entre le joueur et la magnetika, plus ils sont proches plus distanceForce sera elevee
    void DistanceForce ()
    {
        distanceForce = (100f - distance)/45;
        
        if (distanceForce <= 0 )
        {
            distanceForce = -distanceForce;
        }

     
    }

    /*void OnTriggerEnter(Collider col)
    {
        inCol = true;
        Debug.Log("Enter");
    }*/

    /*void OnTriggerExit(Collider col)
    {
        inCol = false;
        Debug.Log("Exit");
        speed = 10f;
    }*/

    /*void OnTriggerStay(Collider col)
    {
        inCol = true;
        //Debug.Log("Stay");
        speed = 5f;
    }


    public void Attraction ()
    {
        //Attire l'entite vers un module avec une force speed
        //float step = speed * Time.deltaTime;
        float step = speed * Time.deltaTime * distanceForce;
        player.transform.position = Vector3.MoveTowards(player.transform.position, module.transform.position, step);

        distance = Vector3.Distance(player.transform.position, module.transform.position);
    }

    public void Repulsion()
    {
        //Attire l'entite vers un module avec une force speed
        float step = - speed * Time.deltaTime + distanceForce;
        player.transform.position = Vector3.MoveTowards(player.transform.position, module.transform.position, step);

        //distance = Vector3.Distance(player.transform.position, module.transform.position);
    }


}*/
