using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VolumeSliderMenu : MonoBehaviour {
    [SerializeField] private Slider slider;
    [SerializeField] private MusicPlayer musicPlayer;
    private void Start() {
        if (PlayerPrefs.GetInt("FirstTimePlaying") != 1) {
            PlayerPrefs.SetFloat("Volume", 1f);
            PlayerPrefs.SetInt("FirstTimePlaying", 1);
        }
        slider.value = PlayerPrefs.GetFloat("Volume");

    }
    public void SaveVolume() {
        PlayerPrefs.SetFloat("Volume", slider.value);
        musicPlayer.GetComponent<AudioSource>().volume = slider.value;
    }
}