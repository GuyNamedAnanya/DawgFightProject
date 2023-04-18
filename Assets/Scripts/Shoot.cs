using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [Header("Firing Stuff")]
    [SerializeField] float firingVariance = 0f;
    [SerializeField] float firingRate = 0.5f;
    [SerializeField] float minFiringRate = 0.1f;

    [Header("General")]
    [SerializeField] float bulletSpeed = 5f;
    [SerializeField] float bulletLife = 5f;

    [SerializeField] GameObject bulletPrefab;

    Coroutine firingCoroutine;


    [HideInInspector]public bool isFiring;
    [SerializeField] bool isEnemy;

    AudioPlayer audioPlayer;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    void Start()
    {
        if(isEnemy)
        {
            isFiring = true;
        }
    }

    
    void Update()
    {
        Fire();
    }

    /// <summary>
    /// Fires bullet based on enemy and player
    /// </summary>
    void Fire()
    {
        if(isFiring && firingCoroutine == null )
        {
            firingCoroutine = StartCoroutine(Firing());
        }
        else if(!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
       
    }

    IEnumerator Firing()
    {
        while(true)
        {
            GameObject bulletInstance = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            Rigidbody2D myRigidbody2D = bulletInstance.GetComponent<Rigidbody2D>();
            if(myRigidbody2D != null)
            {
                // add velocity to the bullet
                myRigidbody2D.velocity = transform.up * bulletSpeed;
            }
            Destroy(bulletInstance, bulletLife);

            //randomness between firing durations
            float firingTime = Random.Range(firingRate - firingVariance, firingRate + firingVariance);
            Mathf.Clamp(firingTime, minFiringRate, firingRate + firingVariance);

            audioPlayer.PlayShootingClip();

            yield return new WaitForSeconds(firingTime);
           
        }
    }
}
