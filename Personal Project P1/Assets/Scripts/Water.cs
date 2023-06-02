using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private float water = 200f;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void OnTriggerStay(Collider collider)
    {

        if (collider.CompareTag("Plant") && (Input.GetKey(KeyCode.Space)))          //hold down space key for interaction
        {
            collider.gameObject.GetComponent<PlantGrowth>().Growth();               //access plant growth script and starts growth method to add to life value
            water -= Time.deltaTime;                                                //rids of water over time with continual use
            //Debug.Log("Water = " + water);
        }

        //stops player from watering if there is no more water
        if (water < 0)
        {
            GameObject.Find("Plant").GetComponent<PlantGrowth>().enabled = false;
            this.GetComponent<Water>().enabled = false;
        }

    }


}
