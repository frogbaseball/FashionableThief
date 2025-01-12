using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
public class CopStateMachine : MonoBehaviour {
    public UnityEvent gameOverEvent;
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.GetComponent<RobberHat>() != null)
            gameOverEvent.Invoke();
    }
    private State currentState = null;
    public State CurrentState { get { return currentState; } }
    [SerializeField] private Vector2[] locationsToSearch;
    [SerializeField] private float speed;
    [SerializeField] private Transform raycastsTransform;
    [SerializeField] NPCRaycast copRaycastScript;
    [SerializeField] private NavMeshAgent navMeshAgent;
    public void CallToLocation(Vector2 location) {
        currentState = new SearchState(navMeshAgent, location, locationsToSearch, transform, raycastsTransform, speed, copRaycastScript);
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