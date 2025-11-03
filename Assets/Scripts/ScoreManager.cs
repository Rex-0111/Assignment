using System.IO;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("Display")]
    [SerializeField] private TMP_Text HighscoreText;
    [SerializeField] private TMP_Text CurrentscoreText;

    private int currentScore = 0;
    private int highestScore = 0;

    public static int ScoreToCarryOver = 0;

    private const string SaveFileName = "/savegame.json";
    private string SavePath;

    [System.Serializable]
    private class ScoreData
    {
        public int highestScore;
    }

    private void Awake()
    {
        SavePath = Application.persistentDataPath + SaveFileName;
    }

    private void Start()
    {
        LoadHighscore();

        if (ScoreToCarryOver > 0)
        {
            UpdateCurrentScore(ScoreToCarryOver);
            ScoreToCarryOver = 0;
        }
        else
        {
            UpdateCurrentScore(0);
        }
    }

    public void UpdateCurrentScore(int newScore)
    {
        currentScore = newScore;
        CurrentscoreText.text = "Score: " + currentScore.ToString();

        if (currentScore > highestScore)
        {
            SetNewHighscore(currentScore);
        }
    }

    private void SetNewHighscore(int score)
    {
        highestScore = score;
        HighscoreText.text = "High Score: " + highestScore.ToString();
        SaveHighscore();
    }

    private void LoadHighscore()
    {
        if (File.Exists(SavePath))
        {
            string jsonString = File.ReadAllText(SavePath);
            ScoreData data = JsonUtility.FromJson<ScoreData>(jsonString);

            highestScore = data.highestScore;
            HighscoreText.text = "High Score: " + highestScore.ToString();
            Debug.Log("High Score Loaded: " + highestScore);
        }
        else
        {
            highestScore = 0;
            HighscoreText.text = "High Score: 0";
            Debug.Log("No save file found. Initialized High Score to 0.");
        }
    }

    private void SaveHighscore()
    {
        ScoreData data = new ScoreData
        {
            highestScore = this.highestScore
        };

        string jsonString = JsonUtility.ToJson(data);
        File.WriteAllText(SavePath, jsonString);
        Debug.Log("High Score Saved to: " + SavePath);
    }
}
