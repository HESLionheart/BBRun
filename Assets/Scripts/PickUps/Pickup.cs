using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    [SerializeField]
    AudioClip clip;
    [SerializeField]
    float effect_time, effect_value;

    public float Effect_Time
    {
        get { return effect_time; }
    }
    public float Effect_Value
    {
        get { return effect_value; }
    }

    private void Start()
    {
    }


    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.PlayClip(clip);
            Destroy(gameObject);
        }
    }
}
