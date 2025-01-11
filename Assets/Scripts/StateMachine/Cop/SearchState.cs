using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SearchState : State {
    private Vector2[] locationsToSearch;
    private Vector3 currentDestination;
    private NPCRaycast copRaycastScript;
    private Transform transform;
    private Transform raycastsTransform;
    private float speed;
    public SearchState(NavMeshAgent navMeshAgent, Vector3 location, Vector2[] locationsToSearch, Transform transform, Transform raycastsTransform, float speed, NPCRaycast copRaycastScript) : base(navMeshAgent) { 
        currentDestination = location;
        this.locationsToSearch = locationsToSearch;
        this.transform = transform;
        this.raycastsTransform = raycastsTransform;
        this.speed = speed;
        this.copRaycastScript = copRaycastScript;
    }
    public override void InitState() {
        navMeshAgent.speed = speed;
        currentDestination = ChangeDestination();
        navMeshAgent.SetDestination(currentDestination);
    }
    public override State TryToChangeState() {
        if (copRaycastScript.IsPlayerDetected)
            return new CatchPlayerState(navMeshAgent, copRaycastScript.Player, speed);
        return this;
    }
    public override void UpdateState() {
        if (Mathf.Abs(Vector3.Distance(transform.position, currentDestination)) <= 0.7) {
            currentDestination = ChangeDestination();
            navMeshAgent.SetDestination(currentDestination);
        }
    }
    private Vector3 ChangeDestination() {
        var rand = Random.Range(0, locationsToSearch.Length);
        return locationsToSearch[rand];
    }
}