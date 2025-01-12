using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RobberHat : MonoBehaviour {
    private Hat currentHat;
    public string HatName { get { return currentHat.HatName; } }
    public string HatPath { get { return currentHat.HatPath; } }
    private void Start() {
        currentHat = new Hat("Head", "");
    }
    public void ChangeHat(Hat newHat) {
        currentHat = newHat;
    }
}