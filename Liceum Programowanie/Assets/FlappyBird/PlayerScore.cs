using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    int score;
    public int highScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    private void Start()
    {
        scoreText.text = "0";
        LoadHighscore();
        highscoreText.text = highScore.ToString();
    }

    public void AddPoint()
    {
        score++;
        scoreText.text = "Score" + score.ToString();

        if(score > highScore)
        {
            highScore = score;
        }
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("highscore", highScore);
    }
    public void LoadHighscore()
    {
        highScore = PlayerPrefs.GetInt("highscore");
    }
}
