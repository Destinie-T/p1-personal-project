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

        if (collider.CompareTag("Plant") && (Input.GetKey(KeyCode.Space)))
        {
            collider.gameObject.GetComponent<PlantGrowth>().Growth();
            water -= Time.deltaTime;
            Debug.Log("Water = " + water);
        }

        if (water < 0)
        {
            GameObject.Find("Plant").GetComponent<PlantGrowth>().enabled = false;
            this.GetComponent<Water>().enabled = false;
        }

    }


}
