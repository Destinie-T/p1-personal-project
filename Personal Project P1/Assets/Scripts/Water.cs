using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private int water;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnTriggerStay(Collider collider)
    {

        if (collider.CompareTag("Plant") && (Input.GetKey(KeyCode.F)))
        {
            collider.gameObject.GetComponent<PlantGrowth>().Growth();
            water--;
        }

    }


}
