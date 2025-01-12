using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct Hat {
    private string hatName;
    private Sprite sprite;
    public string HatName { get { return hatName; } }
    public Sprite Sprite { get { return sprite; } }
    public Hat(string name, Sprite sprite) {
        this.hatName = name;
        this.sprite = sprite;
    }
}