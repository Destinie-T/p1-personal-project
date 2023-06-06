using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    [SerializeField] private float live;
    private int nextUpdate = 3;
    public GameObject alivePlant;
    public GameObject grownPlant;
    public GameObject deadPlant;

    private GameManager gameManager;

    private float goodLife = 50.0f;
    private float overWatered = 150.0f;
    
 
    // Start is called before the first frame update
    void Start()
    {
       gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
      
       live = Random.Range(30, 50);

       //Debug.Log("Live = " + live);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            PlantState();
        }
    }

    public void PlantState()
    {
        if(Time.time>=nextUpdate)                           //if next update is reached
        {
            //Debug.Log(Time.time+">="+nextUpdate);
            nextUpdate = Mathf.FloorToInt(Time.time)+1;      //Change next update (current second + 1).. so every second
            Decay();                                         //Call function
        }

        //show or hide certain plant meshes depending on life it has
        if (live > goodLife)
        {  
            alivePlant.gameObject.SetActive(false);
            grownPlant.gameObject.SetActive(true);
        } else {
            alivePlant.gameObject.SetActive(true);
            grownPlant.gameObject.SetActive(false);
        }
        
        if (live < 1)
        {
            gameObject.tag = "Dead";
            alivePlant.gameObject.SetActive(false);
            deadPlant.gameObject.SetActive(true);
            live = -400;
            

        } else if (live > overWatered)
        {
            alivePlant.gameObject.SetActive(false);
            grownPlant.gameObject.SetActive(false);
            deadPlant.gameObject.SetActive(true);
            live = -400;
        }
    }
    
    public void Growth()
    {
        live += 35f * Time.deltaTime;                       //add to plant life every 35 frames (?)
        //Debug.Log("Live =" + live);
    }

    //Now called once per 1 second
    public void Decay()
    {
        live--;                                             //subtract from plant life
        //Debug.Log("Live =" + live);
    }
 

}
