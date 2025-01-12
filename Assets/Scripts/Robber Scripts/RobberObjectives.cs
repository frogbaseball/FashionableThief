using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class RobberObjectives : MonoBehaviour {
    [SerializeField] private TMP_Text text;
    [SerializeField] private RobberItems robberItemsScript;
    private Objective[] objectives;
    private void Start() {
        objectives = new Objective[5];
        objectives[0] = new Objective(4, "Banana", "Chef_Hat");
        objectives[1] = new Objective(7, "Painting", "Tophat");
        objectives[2] = new Objective(1, "GoldChain", "Beret");
        objectives[3] = new Objective(1, "Diamond", "Chef_Hat");
        objectives[4] = new Objective(1, "Trophy", "Cowboy_Hat");
        UpdateText();
    }
    public void UpdateText() {
        text.text = "";
        for (int i = 0; i < objectives.Length; i++) {
            text.text += $"Steal {CountAmountInInventoryOfItem(objectives[i].itemName)}/{objectives[i].amountOnMap} {objectives[i].itemName} while wearing {objectives[i].hatName} \n";
        }
    }
    private string CountAmountInInventoryOfItem(string itemName) {
        int amount = 0;
        for (int i = 0; i < robberItemsScript.Items.Count; i++) {
            if (robberItemsScript.Items[i] == itemName)
                amount++;
        }
        return amount.ToString();
    }
}