using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.RuleTile.TilingRuleOutput;
public class NPCRaycast : MonoBehaviour {
    [SerializeField] private LayerMask layer;
    private NavMeshAgent agent;
    private bool playerDetected = false;
    private Vector3 playerPosition;
    private GameObject player;
    private Vector3 direction;
    private Direction2D direction2D;
    public bool IsPlayerDetected { get { return playerDetected; } }
    public Vector3 PlayerPosition { get { return playerPosition; } }
    public GameObject Player {  get { return player; } }
    private void Start() {
        agent = GetComponentInParent<NavMeshAgent>();
    }
    private void Update() {
        direction2D = new Direction2D(agent.velocity.x, agent.velocity.y);
        if (agent.isStopped != true)
            direction = direction2D.Direction;
        else
            direction = player.transform.position - transform.position;
        Debug.Log(direction);
    }
    private void FixedUpdate() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 20f, layer);
        transform.rotation = Quaternion.LookRotation(direction);
        try {
            if (hit.collider.GetComponent<RobberHat>() == null) {
                playerDetected = false;
            }
            else {
                playerDetected = true;
                playerPosition = hit.point;
                player = hit.collider.gameObject;
            }
        } catch {
            playerDetected = false;
        }
    }
}