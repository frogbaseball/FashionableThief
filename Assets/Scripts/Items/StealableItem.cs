using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StealableItem : MonoBehaviour {
    [SerializeField] private string item;
    [SerializeField] private string requiredHat;
    private bool isPlayerNearItem = false;
    private RobberHat robberHatScript;
    private RobberItems robberItemsScript;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<RobberHat>() != null) {
            isPlayerNearItem = true;
            robberHatScript = collision.GetComponent<RobberHat>();
            robberItemsScript = collision.GetComponent<RobberItems>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        isPlayerNearItem = false;
    }
    private void Update() {
        if (isPlayerNearItem && Input.GetKey(KeyCode.E) && requiredHat == robberHatScript.HatName) {
            robberItemsScript.AddItem(item);
            Destroy(gameObject);
        }
            
    }
}