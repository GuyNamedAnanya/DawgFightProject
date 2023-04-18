using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float loadDelay = 1.5f;

    Scoring scoring;

    void Awake()
    {
        scoring = FindObjectOfType<Scoring>();
    }


    /// <summary>
    /// Resets the score and restarts the game scene
    /// </summary>
    public void LoadGame()
    {
        scoring.ResetScore();
        SceneManager.LoadScene("Game");
    }

    /// <summary>
    /// For quitting application
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

    /// <summary>
    /// Load main menu scene
    /// </summary>
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    /// <summary>
    /// Load game over scene after a delay
    /// </summary>
    public void LoadGameOver()
    {
        StartCoroutine(WaitToLoad());
    }

    IEnumerator WaitToLoad()
    {
        yield return new WaitForSeconds(loadDelay);
        SceneManager.LoadScene("Game Over");
    }
}
