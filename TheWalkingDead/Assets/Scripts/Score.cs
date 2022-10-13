using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score Instance;

    public Text scoreText;
    public Text highscoreText;

    int score = 0;
    int highscore = 0;

    void Start()
    {
        Instance = this;
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "Score: "+score.ToString();
        highscoreText.text = "High Score: " + highscore.ToString();
    }

    // Update is called once per frame
    public void AddScore()
    {
        score += 100;
        scoreText.text = "Score: " + score.ToString();
        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }
}
