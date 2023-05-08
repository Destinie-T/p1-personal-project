using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    public int difficulty;                                              //What is the difficulty? set at number

    private Button button;                                              //defines button being clicked as button
    private GameManager gameManager;                                    //can call game manager script

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();                                                //gets button clicked
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();      //calls game manager script

        button.onClick.AddListener(SetDifficulty);                                      //clicked button sets difficulty
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty()
    {
        gameManager.StartGame(difficulty);                                              //starts game with set difficulty
    }
}
