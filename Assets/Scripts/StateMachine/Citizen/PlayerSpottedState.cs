using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerSpottedState : State {
    private GuardCaller guardCallerScript;
    private Vector3 positionToCallTo;
    private NPCRaycast citizenRaycastScript;
    private int lastPos;

    //for wander script
    Transform wanderTransform;
    Vector2[] wanderPTWB;
    Transform wanderRaycastsTransform;
    float wanderMaxSuspision;
    float wanderSpeed;
    public PlayerSpottedState(NavMeshAgent navMeshAgent, GuardCaller guardCallerScript, int lastPos, NPCRaycast citizenRaycastScript, Transform wanderTransform, Vector2[] wanderPTWB, Transform wanderRaycastsTransform, float wanderMaxSuspision, float speed) : base(navMeshAgent) { 
        this.guardCallerScript = guardCallerScript;
        positionToCallTo = citizenRaycastScript.PlayerPosition;
        this.citizenRaycastScript = citizenRaycastScript;
        this.wanderMaxSuspision = wanderMaxSuspision;
        wanderSpeed = speed;
        this.wanderPTWB = wanderPTWB;
        this.wanderTransform = wanderTransform;
        this.wanderRaycastsTransform = wanderRaycastsTransform;
        this.lastPos = lastPos;
    }
    public override void InitState() {
        guardCallerScript.CallAllGuardsToPosition(positionToCallTo);
    }
    public override State TryToChangeState() {
        if (!citizenRaycastScript.IsPlayerDetected)
            return new WanderState(navMeshAgent, wanderTransform, wanderPTWB, lastPos, wanderSpeed, wanderRaycastsTransform, citizenRaycastScript, wanderMaxSuspision, guardCallerScript);
        return this;
    }
    public override void UpdateState() {
        return;
    }
}