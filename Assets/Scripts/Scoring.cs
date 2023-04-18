using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    int currentScore = 0;
    int highscore = 0;

    static Scoring instance;

    void Awake()
    {
        //TODO: set highscore using playerprefs
        highscore = PlayerPrefs.GetInt("Highscore");
        
        ManageSingleton();
    }

    /// <summary>
    /// Manage the scoring using singleton pattern
    /// </summary>
    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    //getter method for returning score
    public int GetScore()
    {
        return currentScore;
    }

    //getter method for returning highscore
    public int GetHighscore()
    {
        return highscore;
    }

    /// <summary>
    /// add points(scoreToAdd) to the score
    /// </summary>
    /// <param name="scoreToAdd"></param>
    public void ModifyScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;

        //set highscore if score is greater than previous highscore
        if (currentScore > highscore)
        {
            highscore = currentScore;
            PlayerPrefs.SetInt("Highscore", highscore);
        }
    }

    //reset score when game restarts
    public void ResetScore()
    {
        currentScore = 0;
    }
    
}
