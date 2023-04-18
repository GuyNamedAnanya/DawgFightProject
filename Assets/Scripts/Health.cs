using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 100;
    [SerializeField] int scoreToAdd = 25;
    [SerializeField] ParticleSystem explosionEffect;

    [SerializeField] bool isAplliedToPlayer;
    CameraShake cameraShake;

    AudioPlayer audioPlayer;
    Scoring scoring;
    LevelManager levelManager;
    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoring = FindObjectOfType<Scoring>();
        levelManager = FindObjectOfType<LevelManager>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //Damage class is called whenever we have a collision
        Damage damage = collision.GetComponent<Damage>();

        if(damage != null)
        {
            TakeDamage(damage.DamageDealt());
            audioPlayer.PlayDamageClip();
            HitEffect();
            CameraShake();
            damage.Hit();
        }
    }

    /// <summary>
    /// Getter method for returning health
    /// </summary>
    public int GetHealth()
    {
        return health;
    }

    /// <summary>
    /// Decrease health with every damage taken
    /// </summary>
    /// <param name="damageTaken"></param>
    void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
        if (health <= 0)
        {
            Death();
        }
    }

    /// <summary>
    /// If enemy gets destroyed add points, 
    /// if player gets destroyed load game over scene
    /// </summary>
    void Death()
    {
        if(!isPlayer)
        {
            scoring.ModifyScore(scoreToAdd);
        }
        else
        {
            levelManager.LoadGameOver();
        }
        Destroy(gameObject);
    }

    /// <summary>
    /// Plays the hit VFX
    /// </summary>
    void HitEffect()
    {
        if(explosionEffect!= null)
        {
            ParticleSystem hitParticle = Instantiate(explosionEffect, transform.position,Quaternion.identity);

            //only get destroyed after playing the complete effect
            Destroy(hitParticle, hitParticle.main.duration + hitParticle.main.startLifetime.constantMax);
        }
    }

    /// <summary>
    /// Applies camera shake 
    /// </summary>
    void CameraShake()
    {
        if(cameraShake!= null && isAplliedToPlayer)
        {
            cameraShake.PlayCameraShake();
        }
    }
}
