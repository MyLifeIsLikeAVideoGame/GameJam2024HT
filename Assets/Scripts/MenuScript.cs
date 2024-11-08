using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{
    public TextMeshProUGUI pointsInPowerText;
    public TextMeshProUGUI pointsInSpeedText;
    public TextMeshProUGUI pointsInFirerateText;

    public TextMeshProUGUI statPointsText;
    public static bool gameIsPaused;

    public GameObject pauseMenu;
    public GameObject optionsMenu;

    public float volume;
    public GameObject deathMenu;
    public PlayerStats playerStats;   

    private void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        optionsMenu.SetActive(false);
        pauseMenu.SetActive(false);
        deathMenu.SetActive(false);
        


    }

    public void PlaySound()
    {
        
    }

    public void Back()
    {
        optionsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        gameIsPaused = true;
        statPointsText.SetText("Stat Points: " + playerStats.statPoints);
        pointsInPowerText.SetText("Stat Points: " + playerStats.power);
        pointsInSpeedText.SetText("Stat Points: " + playerStats.speed);
        pointsInFirerateText.SetText("Stat Points: " + playerStats.pointsInFireRate);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        gameIsPaused = false;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex != 0) 
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (playerStats.health <= 0)
        {
            DeathMenu();
        }
    }

    void DeathMenu()
    {
        deathMenu.SetActive(true);
    }

    public void IncreasePower()
    {
        playerStats.IncreasePower();
        statPointsText.SetText("Stat Points: " + playerStats.statPoints);
        pointsInPowerText.SetText("Stat Points: " + playerStats.power);
    }

    public void IncreaseSpeed()
    {
        playerStats.IncreaseSpeed();
        statPointsText.SetText("Stat Points: " + playerStats.statPoints);
        pointsInSpeedText.SetText("Stat Points: " + playerStats.speed);
    }

    public void IncreaseFireRate()
    {
        playerStats.IncreaseFireRate();
        statPointsText.SetText("Stat Points: " + playerStats.statPoints);
        pointsInFirerateText.SetText("Stat Points: " + playerStats.pointsInFireRate);
    }
}
