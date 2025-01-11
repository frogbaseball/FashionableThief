using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CatchPlayerState : State {
    private GameObject player;
    private float speed;
    public CatchPlayerState(NavMeshAgent navMeshAgent, GameObject player, float speed) : base(navMeshAgent) {
        this.player = player;
        this.speed = speed;
    }
    public override void InitState() {
        navMeshAgent.speed = speed;
    }

    public override State TryToChangeState() {
        return this;
    }

    public override void UpdateState() {
        navMeshAgent.SetDestination(player.transform.position);
    }
}