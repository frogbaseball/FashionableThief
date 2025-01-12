using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderState : State {
    private Transform transform;
    private Vector2[] pointsToWalkBetween;
    private Transform raycastsTransform;
    private float speed;
    private float suspision = 0;
    private float maxSuspision;
    private float maxDelay;
    private float delay;
    private NPCRaycast playerDetectionScript;
    private GuardCaller guardCallerScript;
    private int pTWBIndex = 0;
    public WanderState(NavMeshAgent navMeshAgent, Transform transform, Vector2[] pointsToWalkBetween, float speed, float delay, Transform raycastsTransform, NPCRaycast playerDetectionScript, float maxSuspision, GuardCaller guardCallerScript) : base(navMeshAgent) {
        this.transform = transform;
        this.pointsToWalkBetween = pointsToWalkBetween;
        this.speed = speed;
        this.raycastsTransform = raycastsTransform;
        this.playerDetectionScript = playerDetectionScript;
        this.maxSuspision = maxSuspision;
        this.guardCallerScript = guardCallerScript;
        this.maxDelay = delay;
    }
    public WanderState(NavMeshAgent navMeshAgent, Transform transform, Vector2[] pointsToWalkBetween, int continueTo, float speed, Transform raycastsTransform, NPCRaycast playerDetectionScript, float delay, float maxSuspision, GuardCaller guardCallerScript) : base(navMeshAgent) {
        this.transform = transform;
        this.pointsToWalkBetween = pointsToWalkBetween;
        this.speed = speed;
        this.raycastsTransform = raycastsTransform;
        this.playerDetectionScript = playerDetectionScript;
        this.maxSuspision = maxSuspision;
        this.guardCallerScript = guardCallerScript;
        pTWBIndex = continueTo;
        this.maxDelay = delay;
    }
    public override void InitState() {
        navMeshAgent.SetDestination(pointsToWalkBetween[pTWBIndex]);
        navMeshAgent.speed = speed;
        delay = maxDelay;
    }
    public override State TryToChangeState() {
        if (playerDetectionScript.IsPlayerDetected)
            suspision += Time.deltaTime;
        if (suspision > 0 && !playerDetectionScript.IsPlayerDetected)
            suspision -= Time.deltaTime;
        if (suspision >= maxSuspision)
            return new PlayerSpottedState(navMeshAgent, guardCallerScript, pTWBIndex, playerDetectionScript, transform, pointsToWalkBetween, raycastsTransform, maxSuspision, delay, speed);
        return this;
    }
    public override void UpdateState() {
        if (playerDetectionScript.IsPlayerDetected)
            navMeshAgent.isStopped = true;
        else
            navMeshAgent.isStopped = false;
        if (Mathf.Abs(Vector3.Distance(transform.position, (Vector3)pointsToWalkBetween[pTWBIndex])) <= 0.7) {
            delay -= Time.deltaTime;
            if (delay > 0)
                return;
            pTWBIndex++;
            if (pTWBIndex >= pointsToWalkBetween.Length)
                pTWBIndex = 0;
            navMeshAgent.SetDestination(pointsToWalkBetween[pTWBIndex]);
            delay = maxDelay;
        }
    }
}