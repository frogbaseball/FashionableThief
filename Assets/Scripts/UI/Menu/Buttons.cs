using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour {
    public void StartButton() {
        SceneManager.LoadScene("Level-1");
    }
    public void ExitButton() {
        Application.Quit();
    }
}