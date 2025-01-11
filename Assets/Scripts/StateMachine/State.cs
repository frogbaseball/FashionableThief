using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class State {
    protected NavMeshAgent navMeshAgent;
    public State(NavMeshAgent navMeshAgent) {
        this.navMeshAgent = navMeshAgent;
    }
    public abstract void InitState();
    public abstract void UpdateState();
    public abstract State TryToChangeState();
}
