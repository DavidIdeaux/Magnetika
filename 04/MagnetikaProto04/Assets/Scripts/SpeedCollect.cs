using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ValueConstraints.ValueControls.Behaviours;

public class SpeedCollect : MonoBehaviour
{

    public GameObject _Camera;
    float minSpeed = 4f;
    float maxSpeed = 10f;
    float increaseSpeed = 0.5f;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "SpeedCollectible")
        {
            Debug.Log("You got Speed !");

            ChangeSpeed ScriptChangeSpeed = _Camera.GetComponent<ChangeSpeed>();

            ScriptChangeSpeed.UpVitesse();

            Destroy(collision.gameObject);

        }
    }
}