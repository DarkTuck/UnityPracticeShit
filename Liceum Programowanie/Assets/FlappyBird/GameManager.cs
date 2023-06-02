using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverWindow;
    public GameObject startText;
    public GameObject pauseWindow;

    bool gameStarted;
    bool gamePaused;

    private void Start()
    {
        Time.timeScale = 0;
        startText.SetActive(true);
        gameStarted = false;
    }

    private void Update()
    {
        if(!gameStarted)
        {
            if (Input.anyKey)
            {
                StartGame();
               
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if (!gamePaused)
                {
                    Pause();
                }
                else
                {
                    UnPause();
                }
            }

            //pauzowanie gry
        }
    }

    public void OnPlayerDeath()
    {
        Time.timeScale = 0;
        gameOverWindow.SetActive(true);
        FindObjectOfType<PlayerScore>().SaveScore();

    }

    void StartGame()
    {
        Time.timeScale = 1;
        startText.SetActive(false);
        gameStarted = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    void Pause()
    {
        Time.timeScale = 0;
        pauseWindow.SetActive(true);
        gamePaused = true;
    }

    void UnPause()
    {
        Time.timeScale = 1;
        pauseWindow.SetActive(false);
        gamePaused = false;
    }
}
