using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField , Range(0f,1f)] float volume;

    [Header("Damage")]
    [SerializeField] AudioClip damageAudio;
    [SerializeField, Range(0f, 1f)] float damageVolume;

    static AudioPlayer instance;

    void Awake()
    {
        ManageSingleton();
    }

    /// <summary>
    /// Manage audioplayer using singleton 
    /// </summary>
    void ManageSingleton()
    {
        if(instance != null)
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

    /// <summary>
    /// Play shoot sfx 
    /// </summary>
    public void PlayShootingClip()
    {
        if(shootingClip != null)
        {
            AudioSource.PlayClipAtPoint(shootingClip, Camera.main.transform.position, volume);
        }
    }

    /// <summary>
    /// Play damage sfx
    /// </summary>
    public void PlayDamageClip()
    {
        if(damageAudio != null)
        {
            AudioSource.PlayClipAtPoint(damageAudio, Camera.main.transform.position, damageVolume);
        }

    }
}
