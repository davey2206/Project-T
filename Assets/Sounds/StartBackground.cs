using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class StartBackground : MonoBehaviour
{
    [SerializeField] AudioMixerSnapshot backgroundSound;
    private void Start()
    {
        backgroundSound.TransitionTo(0.1f);
    }
}
