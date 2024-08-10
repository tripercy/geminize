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

    private void Update() {
        if (!backgroundMusic.isPlaying) {
            if (backgroundMusic != null) {
            backgroundMusic.clip = sound;
            backgroundMusic.Play();
        }
        }
    }
}
