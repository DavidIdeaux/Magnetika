using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ValueConstraints.ValueControls.Behaviours;


public class Obstacle : MonoBehaviour
{

    float decreaseEnergy = 20f;
    public GameObject _Camera;
    public GameObject MilieuEcran;
    public Vector3 PositionPlayer;
    public Vector3 PositionInitial;



    // Use this for initialization
    void Start()
    {




    }

    // Update is called once per frame
    void Update()
    {

        PositionPlayer = transform.position;
        PositionInitial = MilieuEcran.transform.position;


    }


    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.layer == 10)
        {

            ShieldEnergy ScriptShieldEnergy = GetComponent<ShieldEnergy>();

            ScriptShieldEnergy.currentEnergy -= decreaseEnergy;

            // Diminution de la vitesse

            ChangeSpeed ScriptChangeSpeed = _Camera.GetComponent<ChangeSpeed>();

            ScriptChangeSpeed.LowVitesse();

            // tekeportation du joueur quand il se prend un obstacle

            transform.position = Vector3.Lerp(PositionPlayer, PositionInitial, 0.5f);

            //gameObject.GetComponent<BoxCollider>().enabled = false;



        }

    }
}
