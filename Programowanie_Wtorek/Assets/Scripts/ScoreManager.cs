using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NaughtyAttributes;
using UnityEngine.InputSystem;

public class ScoreManager : MonoBehaviour
{
    [Foldout("UI")][Required][SerializeField]
    GameObject playScene, menuScene,quitButton;
    [Foldout("Timer Setings")][Required][SerializeField]
    TextMeshProUGUI timerText;
    [Foldout("Timer Setings")][SerializeField]
    float time,timeLimit;
    [Foldout("Timer Setings")][SerializeField]
    bool countDown,hasLimit;
    [ShowNonSerializedField]private bool timerRunnig=false;

    [Foldout("Score")][Required][SerializeField]
    TextMeshProUGUI scoreText, lastScoreText;
    [Foldout("Score")][ShowNonSerializedField]
    int lastScore=0;
    int score = 0;

    Actions actions;
    float timeAtStart;

    void OnEnable()
    {
        actions = new Actions();
        actions.Player.Enable();
    }
    private void OnDisable()
    {
        actions.Player.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        timeAtStart = time;
    }
    void Update()
    {
        if (timerRunnig == true)
        {
            time = countDown ? time -= Time.deltaTime : time += Time.deltaTime;
            if (hasLimit && ((countDown && time <= timeLimit) || (!countDown && time >= timeLimit)))
            {
                time = timeLimit;
                SetTimerText();
                timerText.color = Color.red;
                timerRunnig = false;
                quitButton.SetActive(true);
                time = timeAtStart;
                actions.Player.Jump.performed -= Game;
            }
            SetTimerText();
        }
    }
    void SetTimerText()
    {
        timerText.text = time.ToString("0.00");
    }
    public void StartGame()
    {
        actions.Player.Jump.performed += Game;
        menuScene.SetActive(false);
        playScene.SetActive(true);
        timerRunnig = true;
        time = timeAtStart;
        score = 0;
    }
    public void QuitGame()
    {
        menuScene.SetActive(true);
        playScene.SetActive(false);
        quitButton.SetActive(false);
    }
    void Game(InputAction.CallbackContext context)
    {
        score += 1;
        lastScore = score;
        scoreText.text = score.ToString();
        lastScoreText.text = lastScore.ToString();
    }
}
