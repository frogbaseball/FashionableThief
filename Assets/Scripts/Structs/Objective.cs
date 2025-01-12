using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Objective {
    public int amountOnMap;
    public string itemName;
    public string hatName;
    public Objective(int amountOnMap, string itemName, string hatName) {
        this.amountOnMap = amountOnMap;
        this.itemName = itemName;
        this.hatName = hatName;
    }
}
