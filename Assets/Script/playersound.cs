using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playersound : MonoBehaviour {

    public AudioClip walk;
    // public AudioClip walkfast;
    // public AudioClip jump;
    // public AudioClip bigjump;
    AudioSource audiosource;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    public void Walk()
    {
        audiosource.PlayOneShot(walk, 1f);
    }

    // public void walkFast()
    // {
    //     audiosource.PlayOneShot(walkfast, 8f);
    // }

    // public void Jump()
    // {
    //     audiosource.PlayOneShot(jump, 8f);
    // }

    // public void Bigjump()
    // {
    //     audiosource.PlayOneShot(bigjump, 8f);
    // }

}