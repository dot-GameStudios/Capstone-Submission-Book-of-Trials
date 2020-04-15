using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class wolfAudio : MonoBehaviour
{
    public AudioClip damageNoise;
    public AudioClip attackNoise;
    public AudioClip deathNoise;
    public AudioSource output;
    public bool reset = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void damaged()
    {
        output.clip = damageNoise;
        output.Play();
    }

    public void attacking()
    {
        output.clip = attackNoise;
        output.Play();
    }

    public void dying()
    {
        output.clip = deathNoise;
        output.Play();
    }
}
