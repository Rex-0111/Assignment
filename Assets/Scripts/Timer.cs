using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float initialCountdownTime;
    public float countdownTime = 60f;
    public TMP_Text timerText;

    public int currentScore = 0;
    public TMP_Text scoreText;

    public float GetRemainingTime()
    {
        return countdownTime;
    }

    public float GetInitialTime()
    {
        return initialCountdownTime;
    }

    private void Awake()
    {
        initialCountdownTime = countdownTime;
    }

    private void Start()
    {
        UpdateScoreDisplay();
    }

    private void Update()
    {
        if (countdownTime > 0)
        {
            countdownTime -= Time.deltaTime;

            if (countdownTime < 0)
            {
                countdownTime = 0;
            }

            UpdateTimerDisplay(countdownTime);
        }
        else if (countdownTime == 0)
        {
            Debug.Log("Time's Up! Final Score: " + currentScore);
            countdownTime = -1f;
        }
    }

    public void AddScore(int pointsToAdd)
    {
        currentScore += pointsToAdd;
        UpdateScoreDisplay();
    }

    void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore.ToString("N0");
        }
    }

    void UpdateTimerDisplay(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
