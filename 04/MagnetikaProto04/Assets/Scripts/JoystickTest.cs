using UnityEngine;
using System.Collections;

public class JoystickTest : MonoBehaviour
{

    //Permet de savoir si l'avatar bouge
    public bool isMoving = false;

    //si moveSpeed est egal ou superieur a maxMoveSpeed, alors il prend la valeur de maxMoveSpeed
    public float moveSpeed = 10f;

    //valeur qui fixe à quel point la vitesse de l'avatar va augmenter dans le temps
    public float speedUPS;

    //la valeur qui fixe la vitesse maximale et minimale de l'avatar
    float maxMoveSpeed = 30f;
    float minMoveSpeed = 10f;

    //Rigidbody de l'avatar, on applique les deplacements sur lui
    private Rigidbody rigidbody;

    // Player inputs
    private Vector2 sitckInput;

    // Initialisation
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Input tick
    void Update()
    {
        //sitckInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        sitckInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
    }

    // Physic tick
    private void FixedUpdate()
    {
        float dt = Time.fixedTime;
		//transform.parent = Camera.main.transform; --> pour mettre cette transform en enfant de la camera
		Vector3 velocity = Camera.main.transform.TransformDirection (sitckInput * moveSpeed);
		//Vector3 velocity = transform.right * sitckInput.x * moveSpeed + transform.up * sitckInput.y * moveSpeed;		 
        rigidbody.velocity = velocity;

		//print ("vel joy: " + rigidbody.velocity);


        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            moveSpeed += speedUPS * Time.deltaTime;
            isMoving = true;


            if (moveSpeed > maxMoveSpeed)
            {
                moveSpeed = maxMoveSpeed;
            }
        }

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