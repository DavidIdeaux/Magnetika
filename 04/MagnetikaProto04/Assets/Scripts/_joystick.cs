using UnityEngine;
using System.Collections;

public class _joystick : MonoBehaviour
{

    Magnetism increaseForce;

    //Permet de savoir si l'avatar bouge
    public bool isMoving = false;

    //si moveSpeed est egal ou superieur a maxMoveSpeed, alors il prend la valeur de maxMoveSpeed
    public float moveSpeed = 20f;

    //public float _Rotation = 15f;

    //la valeur qui fixe la vitesse maximale et minimale de l'avatar
    public float maxMoveSpeed = 50f;
    public float minMoveSpeed = 20f;

    //valeur qui fixe à quel point la vitesse de l'avatar va augmenter dans le temps
    float speedUPS = 6f;

    float MoveA;
    float MoveB;
    //float MoveC;
    //float MoveD;

    //Rigidbody de l'avatar, on applique les deplacements sur lui
    Rigidbody rig;
    
    

    // Use this for initialization
    void Start()
    {
        
        increaseForce = GetComponent<Magnetism>();
        rig = GetComponent<Rigidbody>();
        //blabla = vaisseau.GetComponent<Rigidbody>();
		//blabla = vaisseau.GetComponent<Transform>();



    }




    // Update is called once per frame
    void Update()
    {

        //IsMoving();
        //Debug.Log("moveSpeed " + moveSpeed);


        MoveA = Input.GetAxis("Horizontal");
        MoveB = Input.GetAxis("Vertical");
        Vector3 Mouvement = transform.TransformDirection(new Vector3(MoveA, MoveB) * moveSpeed * Time.deltaTime);
        rig.MovePosition(transform.position + Mouvement);



        //MoveA = Input.GetAxisRaw("Horizontal") ;
        //transform.Translate (0,0, Time.deltaTime * moveSpeed);
        //MoveB = Input.GetAxisRaw("Vertical");
        //transform.Translate (0,0, Time.deltaTime * moveSpeed);
        //MoveC = Input.GetAxisRaw("LeftJoystickVertical") ;
        //transform.Rotate (0,0, Time.deltaTime * rotation);
        //MoveD = Input.GetAxisRaw("RightJoystickVertical" ) ;
        //transform.Rotate (0,0, Time.deltaTime * rotation);
        //Vector3 Mouvement = transform.TransformDirection ( new Vector3 (-MoveB, 0 , MoveA) * moveSpeed * Time.deltaTime);

        //C'EST POUR LA ROTATION MAIS PAS BESOIN
        //Quaternion _rotation = Quaternion.Euler ( new Vector3 (0, MoveC, 0) * _Rotation * Time.deltaTime);
        //transform.Rotate ( new Vector3 (0, MoveC, 0) * _Rotation * Time.deltaTime);


        //Si le joueur influence la position du l'axe vertical ou horizontal, alors sa vitesse de deplacement augmente petit a petit

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            moveSpeed += speedUPS * Time.deltaTime;
            isMoving = true;


            if (moveSpeed > maxMoveSpeed)
            {
                moveSpeed = maxMoveSpeed;
            }
        }

        //Si le joueur n'influence pas l'axe vertical ou horizontal, reset la vitesse de deplacement a zero
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)

        {
            moveSpeed -= speedUPS * Time.deltaTime + 0.03f;
            isMoving = false;


           if (moveSpeed < minMoveSpeed)
            {
                moveSpeed = minMoveSpeed;
            }

        }

    }

}