using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State {
    public State() {

    }
    public abstract void InitState();
    public abstract void UpdateState();
    public abstract State TryToChangeState();
}
