using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject gameOverScreen;
    private Button button;
    private GameObject plantGrowth;
    public GameObject startingTint;
    public TextMeshProUGUI timerText;

    public int countdownTimer = 60;


    public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator CountdownTimer()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(1.0f);
            countdownTimer--;
            if (isGameActive)
            {
                timerText.text = "Time: " + countdownTimer;
            }

            if (countdownTimer < 1)
            {
                GameOver();
            }
        }
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverScreen.gameObject.SetActive(true);
        startingTint.gameObject.SetActive(true);
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
        GameObject.Find("Plant").GetComponent<PlantGrowth>().enabled = false;
    }


    public void StartGame()
    {
        titleScreen.gameObject.SetActive(false);
        startingTint.gameObject.SetActive(false);
        
        isGameActive = true;
        StartCoroutine(CountdownTimer());
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
