using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverScreen : MonoBehaviour {
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private string[] gameOverPossibleEndings;
    [SerializeField] private TMP_Text text;
    public void EndGame(int index) {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
        text.text = gameOverPossibleEndings[index];
    }
    public void BackToMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}