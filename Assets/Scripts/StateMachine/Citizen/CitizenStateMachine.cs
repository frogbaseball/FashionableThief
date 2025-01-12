using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CitizenStateMachine : MonoBehaviour {
    private State currentState;
    [SerializeField] private GameObject raycastsGameObject;
    [SerializeField] private Vector2[] pointsToWalkBetween;
    [SerializeField] private float delay;
    [SerializeField] private float speed;
    [SerializeField] NPCRaycast citizenRaycastScript;
    [SerializeField] GuardCaller guardCallerScript;
    [SerializeField] NavMeshAgent agent;
    void Start() {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        currentState = new WanderState(agent, transform, pointsToWalkBetween, speed, delay, raycastsGameObject.transform, citizenRaycastScript, citizenRaycastScript.MaxSuspision, guardCallerScript);
        currentState.InitState();
    }
    void Update() {
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