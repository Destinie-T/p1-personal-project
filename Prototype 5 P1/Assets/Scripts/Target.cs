using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;                                        //objects' rigidbody
    private GameManager gameManager;                                   //get GameManager script
    public ParticleSystem explosionParticle;

    private float minSpeed = 12;                                       //lowest object speed of upward movement
    private float maxSpeed = 15;                                       //highest speed of upward movement
    private float maxTorque = 10;                                      //maximum spin
    private float xRange = 4;                                          //min/max range of object spawn on x-axis
    private float ySpawnPos = -2;                                      //y pos of object
    
    public int pointValue;                                             //how many points an object is worth

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();                                                       //Calls rigidbody component
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();                  //sets gameManager as game manager script

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);                                        //Random upward force on object
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);      //Random spinning force on object in all directions

        transform.position = RandomSpawnPos();                                                      //Random spawn, z = 0 therefore not included

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Click w/ mouse to destroy
    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            gameManager.UpdateScore(pointValue);                                                            //Each click adds 5 points to score
            Destroy(gameObject);                                                                            //Destroy object when clicked
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);       //spawn explosion at object position when clicked on and destroyed
        }
        
    }
    
    //Collide with sensor and destroyed if tagged "Bad"
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }

    //Returns a Vector3 value that's NEW to the game so it can be manipulated
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
    
    //Returns Vector3 value based on RandomSpawnPos
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    
    //Returns random number that determines spin direction
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
}
