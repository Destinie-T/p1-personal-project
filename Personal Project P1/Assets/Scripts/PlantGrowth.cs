using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth : MonoBehaviour
{

    Renderer ren;                               //mesh renderer of the plant

    private float amITimer = 5.0f;              //5 sec countdown

    // Start is called before the first frame update
    void Start()
    {
        ren = GetComponent<Renderer>();         //get mesh renderer of plant sphere

    }

    // Update is called once per frame
    public void Update()
    {
        //maybe find a better way to check if player has can?
            

    }
    
    //start countdown to see if player is there for long enough (ideally), for now its just the watering one again
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Front"))
        {
            StartCoroutine(AmICountdownRoutine());
        }
    
    }
    IEnumerator AmICountdownRoutine()
    {
        yield return new WaitForSeconds(amITimer);          //waters for set amount of time
        ren.material.color = Color.blue;                    //turns plant from red to blue
    }

}
