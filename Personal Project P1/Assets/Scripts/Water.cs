using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public bool hasCan = false;

    private float waterTimer = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnTriggerEnter(Collider other)
    {
         if (other.CompareTag("Can"))            //Checks tag of object and if player doesn't have powerup
        {
            hasCan = true;  
        }

         if (other.CompareTag("Plant") && hasCan == true)            //Checks tag of object and if player doesn't have powerup
        {
           Debug.Log("Watering plant!");
           StartCoroutine(WateringCountdownRoutine());
        }
    }

    IEnumerator WateringCountdownRoutine()
    {
        yield return new WaitForSeconds(waterTimer);
        Debug.Log("Watering done!");
    }


}
