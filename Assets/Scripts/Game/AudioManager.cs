using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio source")]
    [SerializeField] AudioSource backgroundMusic;

    [Header("List Sound")]
    public AudioClip sound;

    private void Start() {
        if (backgroundMusic != null) {
            backgroundMusic.clip = sound;
            backgroundMusic.Play();
        }
    }
}
