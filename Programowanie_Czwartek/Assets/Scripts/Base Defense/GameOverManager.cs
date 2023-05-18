using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] GameObject gameoverWindow;
    AudioSource audioSource;

    private void Start()
    {
        gameoverWindow.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    public void GameOver()
    {
        gameoverWindow.SetActive(true);
        audioSource.Play();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
