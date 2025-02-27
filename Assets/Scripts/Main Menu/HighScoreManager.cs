using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    public TMP_Text highScoreText;

    void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    public void UpdateHighScore(int score)
    {
        int currentHighScore = PlayerPrefs.GetInt("HighScore", 0);

        if (score > currentHighScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
        }
    }
}
