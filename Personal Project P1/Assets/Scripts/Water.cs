using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public bool hasCan = false;                             //Starts off with minican as false

    private float waterTimer = 5.0f;                        //Watering timer is 5 seconds


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
        //maybe find a better way to check if player has can?

         if (other.CompareTag("Can"))                         //Checks tag of object and if player doesn't have can
        {
            hasCan = true;                                    //Player holds minican TRUE
        }

         if (other.CompareTag("Plant") && hasCan == true)     //Checks tag of object and if "front" detects plant AND if player has watering can
        {
           Debug.Log("Watering plant!");                      //Console shows text, know it works now
           StartCoroutine(WateringCountdownRoutine());        //Start watering countdown
        }
    }

    public IEnumerator WateringCountdownRoutine()
    {
        yield return new WaitForSeconds(waterTimer);          //waters for set amount of time
        Debug.Log("Watering done!");                          //Once finished, text in console
    }


}
