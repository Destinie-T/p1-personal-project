using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject titleScreen;                                  //the title screen
    public GameObject gameOverScreen;                               //the game over screen
    private Button button;                                          //a button
    private GameObject plantGrowth;                                 //i dont know why this is here
    public GameObject startingTint;                                 //black tint on camera during start/restart
    public TextMeshProUGUI timerText;                               //text for timer
    public TextMeshProUGUI deathCounterText;                        //text for amt of plants dead

    public int countdownTimer = 60;                                 //timer starts at 60 secs
    public int deadPlant;                                           //number of dead plants in game


    public bool isGameActive;                                       //game starts as "not active"

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;         //when game runs, player cannot move
        
    }

    // Update is called once per frame
    void Update()
    {
        deadPlant = GameObject.FindGameObjectsWithTag("Dead").Length;                       //count number of game objects with "dead" tag
    }
    
    //60 second timer that runs while game is active
    IEnumerator CountdownTimer()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(1.0f);                      //counts per second
            countdownTimer--;                                           //timer goes down by 1
            if (isGameActive)
            {
                timerText.text = "Time: " + countdownTimer;
            }

            if (countdownTimer < 1)                                     //if timer reaches 0, game over screen appears
            {
                GameOver();
            }

            if (deadPlant > 11)                                         //if all plants are dead, game over screen appears
            {
                GameOver();
            }
        }
    }

    public void GameOver()
    {
        isGameActive = false;                                                           //game isnt running anymore
        gameOverScreen.gameObject.SetActive(true);                                      //game over screen is shown
        startingTint.gameObject.SetActive(true);                                        //black tint is shown
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;     //player cannot move
        GameObject.Find("Plant").GetComponent<PlantGrowth>().enabled = false;           //plants cannot add more to their life counter
        deathCounterText.text = "Plants Dead: " + deadPlant;                            //display number of plants dead (count of game objects with "dead" tag)
        //Debug.Log(deadPlant);                 

    }


    public void StartGame()
    {
        titleScreen.gameObject.SetActive(false);                                        //starting game... title screen disappears
        startingTint.gameObject.SetActive(false);                                       //black tint disappears
        
        isGameActive = true;                                                            //game is now up and running
        StartCoroutine(CountdownTimer());                                               //starts timer
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;      //player can now move
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);                     //reloads scene when restart button is hit
    }

}
