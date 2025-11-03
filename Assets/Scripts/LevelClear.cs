using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelClear : MonoBehaviour
{
    private Timer timer;

    private void Start()
    {
        timer = Object.FindAnyObjectByType<Timer>();
 //       FindObjectOfType<Timer>();
        if (timer == null)
        {
            Debug.LogError("Timer script not found in the scene! Cannot calculate time score.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int scoreFromTime = 0;

            if (timer != null)
            {
                float initialTime = timer.GetInitialTime();
                float timeRemaining = timer.GetRemainingTime();
                float timeElapsed = initialTime - timeRemaining;

                scoreFromTime = Mathf.FloorToInt(timeElapsed * 10f);
            }

            int totalScore = timer.currentScore + scoreFromTime;

            ScoreManager.ScoreToCarryOver = totalScore;

            Debug.Log("Level Cleared! Passing Score: " + totalScore + " to next scene.");
            SceneManager.LoadScene(2);
        }
    }
}
