using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Audio
{
    None,
    Pickup,
    Enemy
}

public class AudioManager : MonoBehaviour {

    [SerializeField]
    AudioSource music_audio_source,pickup_audio_source;

    public static AudioManager instance;


    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void PlayClip(Audio type,AudioClip clip)
    {
        if(type==Audio.Pickup)
        {
            pickup_audio_source.clip = clip;
            pickup_audio_source.Play();
        }
    }
}
