using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CopStateMachine : MonoBehaviour {
    private State currentState;
    [SerializeField] private Vector2[] locationsToSearch;
    [SerializeField] private float speed;
    [SerializeField] private Transform raycastsTransform;
    [SerializeField] NPCRaycast copRaycastScript;
    public void CallToLocation(Vector2 location) {
        currentState = new SearchState(location, locationsToSearch, transform, raycastsTransform, speed, copRaycastScript);
        currentState.InitState();
    }
    private void Update() {
        if (currentState != null) {
            currentState.UpdateState();
            var newState = currentState.TryToChangeState();
            if (newState != currentState) {
                currentState = newState;
                currentState.InitState();
            }
        }
    }
}