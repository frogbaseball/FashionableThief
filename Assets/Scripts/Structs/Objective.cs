using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Objective {
    public int amountOnMap;
    public string itemName;
    public string displayItemName;
    public string hatName;
    public string displayHatName;
    public Objective(int amountOnMap, string itemName, string hatName, string displayItemName, string displayHatName) {
        this.amountOnMap = amountOnMap;
        this.itemName = itemName;
        this.hatName = hatName;
        this.displayHatName = displayHatName;
        this.displayItemName = displayItemName;
    }
}
