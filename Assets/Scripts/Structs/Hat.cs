using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct Hat {
    private string hatName;
    public string HatName { get { return hatName; } }
    public Hat(string name) {
        this.hatName = name;
    }
}