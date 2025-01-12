using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct Hat {
    private string hatName;
    private string hatPath;
    public string HatName { get { return hatName; } }
    public string HatPath {  get { return hatPath; } }
    public Hat(string name, string hatPath) {
        this.hatName = name;
        this.hatPath = hatPath;
    }
}