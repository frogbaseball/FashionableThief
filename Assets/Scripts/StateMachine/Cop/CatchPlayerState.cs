using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CatchPlayerState : State {
    private GameObject player;
    private Transform transform;
    private Transform raycastsTransform;
    private float speed;
    public CatchPlayerState(GameObject player, Transform transform, Transform raycastsTransform, float speed) : base() {
        this.player = player;
        this.transform = transform;
        this.raycastsTransform = raycastsTransform;
        this.speed = speed;
    }
    public override void InitState() {
        return;
    }

    public override State TryToChangeState() {
        return this;
    }

    public override void UpdateState() {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);
        raycastsTransform.right = player.transform.position - transform.position;
    }
}