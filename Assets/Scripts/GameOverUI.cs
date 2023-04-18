using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highscoreText;

    Scoring scoring;

    void Awake()
    {
        scoring = FindObjectOfType<Scoring>();        
    }
    void Start()
    {
        //shows the final score in the game over scene
        scoreText.text = "Final Score : " + scoring.GetScore();
        
        //shows the highscore in the game over scene
        highscoreText.text = "HI score : " + scoring.GetHighscore();
    }

    
    
}
