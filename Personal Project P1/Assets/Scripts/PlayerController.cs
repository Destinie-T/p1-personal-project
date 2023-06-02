using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;                 //player's rigidbody
    public GameObject HoldCan;                  //The can in the game on the floor


    private float speed = 10.0f;                //How fast the player moves
    
    private float inputX;                       //Left/right input number to calculate
    private float inputY;                       //Up/down input to calculate

    private float xRange = 19.0f;               //area on x-axis where player can move around
    private float zRange = 19.0f;               //area on z-axis where player can move around

    public bool hasCan;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        RotatePlayer();                                 //Call RotatePlayer so player can turn
        MovePlayer();                                   //Call MovePlayer void, way to keep update clean
        ConstrainPlayerPosition();                      //Call Constrain... so player doesn't fall
    }

    void RotatePlayer()
    {
        if (inputX != 0 || inputY != 0)
        {
            float rotationY = Mathf.Atan2(inputX, inputY) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, rotationY, 0);
        }

    }
    
    // Up/down/left/right input to move
    void MovePlayer()
    { 
        float input = Mathf.Sqrt(Mathf.Pow(inputX, 2) + Mathf.Pow(inputY, 2));

        transform.Translate(Vector3.forward * input * speed * Time.deltaTime);

    }
    
    //Don't fall off the edge, all boundaries for the player
    void ConstrainPlayerPosition()
    {
        //If x or z value is less than range given, then stop the player from falling!

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
         if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

         if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }

         if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }

    }
  
}
