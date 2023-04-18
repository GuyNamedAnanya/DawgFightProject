using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    
    [SerializeField] Slider healthSlider;

    Scoring scoring;
    Health health;

    void Awake()
    {
        scoring = FindObjectOfType<Scoring>();
        health = FindObjectOfType<Health>();
    }
    
    void Start()
    {
        //sets the slider's max value to health of player at the start
        healthSlider.maxValue = health.GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = scoring.GetScore().ToString("000000000");

        //sets the slider as per the health of player
        healthSlider.value = health.GetHealth();
    }
}
