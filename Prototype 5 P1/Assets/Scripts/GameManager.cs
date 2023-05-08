using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;                            //Gives game objects a number value via list
    private float spawnRate = 1.0f;                             //Spawns every 1 seconds
    private int score;                                          //the score number
    public GameObject titleScreen;                              //defines what the title screen is
    public Button restartButton;                                //defines the button
    public TextMeshProUGUI scoreText;                           //defines text for score
    public TextMeshProUGUI gameOverText;                        //defines text for game over

    public bool isGameActive;                                   //is game running?

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {
        isGameActive = false;                                   //game over = game not running
        gameOverText.gameObject.SetActive(true);                //shows game over text
        restartButton.gameObject.SetActive(true);               //shows restart button
    }

    IEnumerator SpawnTarget()
    {
        while(isGameActive)                                     //if() and forLoop baby
        {
            yield return new WaitForSeconds(spawnRate);         //Waits for 1 second before...
            int index = Random.Range(0, targets.Count);         //...retrieving a random object...
            Instantiate(targets[index]);                        //...and spawning that object

        }
    }

    //adds certain amount of points to score value
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;                            //add value to current score
        scoreText.text = "Score: " + score;             //Text tells current score
    }

    //reloads the scene and restarts the game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        titleScreen.gameObject.SetActive(false);                //hides title screen after clicking difficulty/starting game
        isGameActive = true;                                    //game is running!
        spawnRate /= difficulty;                                //changes spawn rate according to difficulty (divide spawn by difficulty)

        StartCoroutine(SpawnTarget());                          //Start Spawn Target timer
        score = 0;                                              //Score is set to 0
        UpdateScore(0);                                         //score starts at 0
        
    }
}
