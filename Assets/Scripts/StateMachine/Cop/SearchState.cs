using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SearchState : State {
    private Vector2[] locationsToSearch;
    private Vector3 currentDestination;
    private NPCRaycast copRaycastScript;
    private Transform transform;
    private Transform raycastsTransform;
    private float speed;
    public SearchState(Vector3 location, Vector2[] locationsToSearch, Transform transform, Transform raycastsTransform, float speed, NPCRaycast copRaycastScript) : base() { 
        currentDestination = location;
        this.locationsToSearch = locationsToSearch;
        this.transform = transform;
        this.raycastsTransform = raycastsTransform;
        this.speed = speed;
        this.copRaycastScript = copRaycastScript;
    }
    public override void InitState() {
        return;
    }
    public override State TryToChangeState() {
        if (copRaycastScript.IsPlayerDetected)
            return new CatchPlayerState(copRaycastScript.Player, transform, raycastsTransform, speed);
        return this;
    }
    public override void UpdateState() {
        transform.position = Vector3.MoveTowards(transform.position, currentDestination, Time.deltaTime * speed);
        raycastsTransform.right = currentDestination - transform.position;
        if (Mathf.Abs(Vector3.Distance(transform.position, currentDestination)) <= 1) {
            currentDestination = ChangeDestination();
        }
    }
    private Vector3 ChangeDestination() {
        var rand = Random.Range(0, locationsToSearch.Length);
        return locationsToSearch[rand];
    }
}