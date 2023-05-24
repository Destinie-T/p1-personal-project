using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;                 //player's rigidbody
    public GameObject HoldCan;                  //The can in the game on the floor
    

    private float speed = 10.0f;                //How fast the player moves
    private float turnSpeed = 120.0f;           //How fast the player turns
    
    private float horizontalInput;              //Left/right input number to calculate
    private float verticalInput;                //Up/down input to calculate

    private float xRange = 19.0f;               //area on x-axis where player can move around
    private float zRange = 19.0f;               //area on z-axis where player can move around

    public bool hasCan = false;

    private int water = 100;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void Update()
    {
        MovePlayer();                                   //Call MovePlayer void, way to keep update clean
        ConstrainPlayerPosition();                      //Call Constrain... so player doesn't fall
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Can"))                    //Checks tag of object and if player doesn't have can
        {
            hasCan = true;                              //Player has can
            Destroy(other.gameObject);                  //Destroy large can object

            HoldCan.gameObject.SetActive(true);         //Minican is visible in-game
            Debug.Log("Water = " + water);
        }
    }

    // Up/down/left/right input to move
    void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);      //Move with up/down input
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);        //Turn with left/right input

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
