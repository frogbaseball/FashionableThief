using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MusicPlayer : MonoBehaviour {
    [SerializeField] private AudioClip[] clips;
    private AudioSource audioSource;
    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayMusic(int index) {
        audioSource.loop = false;
        audioSource.clip = clips[index];
        audioSource.Play();
    }
    public void PlayMusicOnLoop(int index) {
        audioSource.loop = true;
        audioSource.clip = clips[index];
        audioSource.Play();
    }
    public void StopMusic() {
        audioSource.Stop();
    }
}