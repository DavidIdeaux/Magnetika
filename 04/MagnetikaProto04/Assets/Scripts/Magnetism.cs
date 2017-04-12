using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnetism : MonoBehaviour
{
    _joystick moveForce;

    JoystickTest speedBySecond;

    public Transform player;
    //public Rigidbody playerRig;
    public Transform module;
    public float speedAttraction = 5f;
    float movingPenalty;
    public float step;

    //variable qui represente la distance entre l'avatar et un module
    float distance;

    //variable qui augmente au fur et a mesure que la distance entre l'avatar et le module diminue
    float distanceForce;

    //float v1;
    //float v2;
    //float v3;

    // Use this for initialization
    void Start()
    {
        moveForce = GetComponent<_joystick>();
		speedBySecond = FindObjectOfType<JoystickTest>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
		
		distance = Vector3.Distance(player.transform.position, module.transform.position);
        MagnetikaFunctionForce();
        IsMoving();
        //module.LookAt(player);
        //Debug.Log("movingPenalty " + movingPenalty);
        //Debug.Log("distanceForce " + distanceForce);
        //Debug.Log("distance " + distance);
        //Attraction();

        if (distance < 60)
        {
            DistanceForce();
        }
    }

    //Permet de savoir combien il y a de Magnetika dans la scene, et de varier la force d'attraction en fonction du nombre de Magnetika
    void MagnetikaFunctionForce()
    {
        int numberMagnetika = GameObject.FindGameObjectsWithTag("Magnetika").Length;
        //Debug.Log("numberMagnetika " + numberMagnetika);
        //Debug.Log("speedAttraction " + speedAttraction);

        if (numberMagnetika == 1)
        {
            speedAttraction = 6;
            speedBySecond.speedUPS = 0.75f;
        }

        if (numberMagnetika == 2)
        {
            speedAttraction = 10;
            speedBySecond.speedUPS = 1f;
        }

        //print(speedBySecond.speedUPS);
    }

    //DistanceForce est une fonction qui recupere la distance entre le joueur et la magnetika, plus ils sont proches plus distanceForce sera elevee
    public void DistanceForce()
    {
        distanceForce = (100 - distance) / 65;

        if (distanceForce <= 1)
        {
            distanceForce = 1;
        }
    }

    //Attire l'entite vers un module avec une force speed
    public void Attraction()
    {
//        step = speedAttraction * Time.deltaTime * distanceForce;
		step = speedAttraction * Time.deltaTime * distanceForce;
		Vector3 dir = module.transform.position - player.transform.position;
		dir.Normalize ();
		Vector3 force = dir * speedAttraction * distanceForce;
		player.GetComponent<Rigidbody> ().velocity += force;
		//print ("adding force: " + force);
		//print ("resulting velocity: " + player.GetComponent<Rigidbody> ().velocity);
        //player.transform.position = Vector3.MoveTowards(player.transform.position, module.transform.position, step);

        //playerRig.MovePosition(player.transform.position - module.transform.position);

        //		print (step);

        //Debug.Log(step);

        //distance = Vector3.Distance(player.transform.position, module.transform.position);
    }

    //Repousse l'entite du module avec une force speed
    public void Repulsion()
    {
		
        step = -speedAttraction * Time.deltaTime * distanceForce;
		Vector3 dir = player.position - module.position;
		dir.Normalize ();
		Vector3 force = dir * speedAttraction * distanceForce;
		player.GetComponent<Rigidbody> ().velocity += force;
		//print ("adding force: " + force);
		//print ("resulting velocity: " + player.GetComponent<Rigidbody> ().velocity);
        //player.transform.position = Vector3.MoveTowards(player.transform.position, module.transform.position, step);

        //distance = Vector3.Distance(player.transform.position, module.transform.position);
    }


    //Permet d'augmenter la force d'attraction ou de repulsion lorsque le joueur ne se deplace pas
    public void IsMoving()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            movingPenalty = 1f;
            //Debug.Log("niiiiii");
        }

        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)

        {
            movingPenalty = 5f;
            //Debug.Log("kyaaaaa");
        }
    }


}

