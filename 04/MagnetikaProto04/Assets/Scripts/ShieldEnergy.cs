using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnergy : MonoBehaviour
{

    public float currentEnergy = 100f;
    float minEnergy = 0f;
    float maxEnergy = 50f;
    public float gainEnergy = 20f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



    }

    void FixedUpdate()
    {
        currentEnergy -= 1 * Time.deltaTime;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "ShieldCollectible")
        {
            Debug.Log("You got Shield !");
            currentEnergy += gainEnergy;
            Destroy(collision.gameObject);
        }


    }

    public void GetSpeedCollectible()
    {

    }

    public void GetShieldCollectible()
    {

    }
}
