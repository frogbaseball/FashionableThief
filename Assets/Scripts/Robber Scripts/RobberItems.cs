using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobberItems : MonoBehaviour {
    private List<string> items = new List<string>();
    public List<string> Items { get { return items; } }
    public void AddItem(string item) {
        items.Add(item);
    }
}