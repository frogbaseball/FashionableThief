using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FinishLine : MonoBehaviour {
    [SerializeField] private int minItemAmount;
    [SerializeField] private GameOverScreen gameOverScreenScript;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<RobberItems>().Items.Count >= minItemAmount) {
            gameOverScreenScript.EndGame(1);
        }
    }
}