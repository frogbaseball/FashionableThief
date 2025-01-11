using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : State {
    private Transform transform;
    private Vector2[] pointsToWalkBetween;
    private Transform raycastsTransform;
    private float speed;
    private float suspision = 0;
    private float maxSuspision;
    private NPCRaycast playerDetectionScript;
    private GuardCaller guardCallerScript;
    private int pTWBIndex = 0;
    private bool startFromFirstPos = true;
    public WanderState(Transform transform, Vector2[] pointsToWalkBetween, float speed, Transform raycastsTransform, NPCRaycast playerDetectionScript, float maxSuspision, GuardCaller guardCallerScript) : base() {
        this.transform = transform;
        this.pointsToWalkBetween = pointsToWalkBetween;
        this.speed = speed;
        this.raycastsTransform = raycastsTransform;
        this.playerDetectionScript = playerDetectionScript;
        this.maxSuspision = maxSuspision;
        this.guardCallerScript = guardCallerScript;
    }
    public WanderState(Transform transform, Vector2[] pointsToWalkBetween, int continueTo, bool startFromFirstPos, float speed, Transform raycastsTransform, NPCRaycast playerDetectionScript, float maxSuspision, GuardCaller guardCallerScript) : base() {
        this.transform = transform;
        this.pointsToWalkBetween = pointsToWalkBetween;
        this.speed = speed;
        this.raycastsTransform = raycastsTransform;
        this.playerDetectionScript = playerDetectionScript;
        this.maxSuspision = maxSuspision;
        this.guardCallerScript = guardCallerScript;
        pTWBIndex = continueTo;
        this.startFromFirstPos = startFromFirstPos;
    }
    public override void InitState() {
        if (startFromFirstPos == true)
            transform.position = pointsToWalkBetween[0];
    }
    public override State TryToChangeState() {
        if (playerDetectionScript.IsPlayerDetected)
            suspision += Time.deltaTime;
        if (suspision >= maxSuspision)
            return new PlayerSpottedState(guardCallerScript, pTWBIndex, playerDetectionScript, transform, pointsToWalkBetween, raycastsTransform, maxSuspision, speed);
        return this;
    }
    public override void UpdateState() {
        if (!playerDetectionScript.IsPlayerDetected)
            transform.position = Vector3.MoveTowards(transform.position, pointsToWalkBetween[pTWBIndex], Time.deltaTime * speed);
        raycastsTransform.right = (Vector3)pointsToWalkBetween[pTWBIndex] - transform.position;
        if (Mathf.Abs(Vector3.Distance(transform.position, (Vector3)pointsToWalkBetween[pTWBIndex])) <= 1) {
            pTWBIndex++;
        }
        if (pTWBIndex >= pointsToWalkBetween.Length) {
            pTWBIndex = 0;
        }
    }
}