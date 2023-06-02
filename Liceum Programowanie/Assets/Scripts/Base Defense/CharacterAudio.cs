using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAudio : MonoBehaviour
{
    AudioSource source;
    public AudioClip stepClip;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    public void PlayStepSound()
    {
        source.PlayOneShot(stepClip);
    }
}
