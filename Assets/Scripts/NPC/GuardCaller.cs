using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GuardCaller : MonoBehaviour {
    private GameObject[] cops;
    [SerializeField] private GameObject copPrefab;
    [SerializeField] private Vector3 callPosition;
    [SerializeField] private int copsAmount;
    public void CallAllGuardsToPosition(Vector3 position) {
        if (cops == null)
            CallCopsToPlace();
        for (int i = 0; i < cops.Length; i++) {
            cops[i].GetComponent<CopStateMachine>().CallToLocation(position);
        }
    }
    public void CallCopsToPlace() {
        cops = new GameObject[copsAmount];
        for (int i = 0; i < cops.Length; i++) {
            cops[i] = Instantiate(copPrefab, callPosition + Vector3.right * i, Quaternion.identity);
        }
    }
}