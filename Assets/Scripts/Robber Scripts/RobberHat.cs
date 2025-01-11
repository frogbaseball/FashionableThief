using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RobberHat : MonoBehaviour {
    private Hat currentHat;
    public string HatName { get { return currentHat.HatName; } }
    public void ChangeHat(Hat newHat) {
        currentHat = newHat;
    }
    private void Update() {
        Debug.Log(currentHat.HatName);
    }
}