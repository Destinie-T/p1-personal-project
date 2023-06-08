using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private Button button;                                              //defines button being clicked as button
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();                                                //gets button clicked
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();      //accesses game manager

        button.onClick.AddListener(GameStart);                                          //listens for when button is clicked
    }

    public void GameStart()
    {
        gameManager.StartGame();                                                        //starts game when button is clicked
    }
}
