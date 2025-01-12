using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class RobberStaminaVisualizer : MonoBehaviour {
    [SerializeField] private TMP_Text text;
    [SerializeField] private RobberSprint robberSprintScript;
    private void Update() {
        text.text = $"SPRINT: {(int)robberSprintScript.Sprint}/{robberSprintScript.MaxSprint}";
    }
}