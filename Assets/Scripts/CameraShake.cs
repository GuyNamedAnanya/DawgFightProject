using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float cameraShakeDuration = 1f;
    [SerializeField] float cameraShakeMagnitude = 0.5f;

    Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;        
    }

    public void PlayCameraShake()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float elapsedTime = 0;
        //camera shake happens until elapsed time is less than shake duration
        while(elapsedTime < cameraShakeDuration)
        {
            elapsedTime += Time.deltaTime;

            //camera position moves to a new position inside a unit circle based on shake magnitude 
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * cameraShakeMagnitude;
            yield return new WaitForEndOfFrame();
        }
        transform.position = initialPosition;

    }


   
}
