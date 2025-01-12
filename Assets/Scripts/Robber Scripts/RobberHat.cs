using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RobberHat : MonoBehaviour {
    private Hat currentHat;
    public string HatName { get { return currentHat.HatName; } }
    public Sprite HatSprite { get { return currentHat.Sprite; } }
    private void Start() {
        currentHat = new Hat("Head", null);
    }
    public void ChangeHat(Hat newHat) {
        currentHat = newHat;
    }
}