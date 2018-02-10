using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    [SerializeField]
    AudioSource audio;

    public static AudioManager instance;


    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        audio = GetComponent<AudioSource>();
    }

    public void PlayClip(AudioClip clip)
    {
        audio.PlayOneShot(clip, 1f);
    }
}
