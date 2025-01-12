using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundPlayer : MonoBehaviour {
    private AudioSource audioSource;
    [SerializeField] private bool randomPitch;
    private void Start() {
        audioSource = GetComponent<AudioSource>();
        GetComponent<AudioSource>().loop = false;
        if (randomPitch)
            audioSource.pitch = Random.Range(0.0f, 1.0f);
        GetComponent<AudioSource>().Play();
    }
    private void Update() {
        if (!GetComponent<AudioSource>().isPlaying)
            Destroy(gameObject);
    }
}