using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    private int live = 50;
    private int nextUpdate = 3;
 
    // Start is called before the first frame update
    void Start()
    {
       Debug.Log("Live = " + live);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time>=nextUpdate)                           //if next update is reached
        {
            Debug.Log(Time.time+">="+nextUpdate);
            nextUpdate = Mathf.FloorToInt(Time.time)+3;      //Change next update (current second + 5)
            Decay();                                        //Call function
        }

        if (live > 70)
        {
            transform.localScale = new Vector3(transform.localScale.x, 2f, transform.localScale.z);
        }
    }
    
    public void Growth()
    {
        live++;
        Debug.Log("Live =" + live);
    }

    //Now called once per 3 second
    public void Decay()
    {
        live--;
        Debug.Log("Live =" + live);
    }
 

}
