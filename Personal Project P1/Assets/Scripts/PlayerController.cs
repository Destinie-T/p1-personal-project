using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    private float speed = 10.0f;
    private float turnSpeed = 120.0f;
    
    private float horizontalInput;
    private float verticalInput;

    private float xRange = 19.0f;
    private float zRange = 19.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();

    }

    //Arrow input to move
    void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);

    }
    
    //Don't fall off the edge
    void ConstrainPlayerPosition()
    {
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
