using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HatItem : MonoBehaviour {
    private Hat hat;
    [SerializeField] private string hatName;
    private bool isPlayerNearItem = false;
    private RobberHat robberHatScript;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<RobberHat>() != null) {
            isPlayerNearItem = true;
            robberHatScript = collision.GetComponent<RobberHat>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        isPlayerNearItem = false;
    }
    private void Update() {
        if (isPlayerNearItem && Input.GetKey(KeyCode.E))
            robberHatScript.ChangeHat(hat);
    }
    private void Start() {
        hat = new Hat(hatName);
    }
}