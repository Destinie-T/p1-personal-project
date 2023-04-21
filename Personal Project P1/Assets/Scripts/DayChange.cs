using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayChange : MonoBehaviour
{
    
    public float rotationSpeed;                                             //How fast the sun spins, therefore how long the day is

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);      //Sun rotates based on y-axis
    }
}
