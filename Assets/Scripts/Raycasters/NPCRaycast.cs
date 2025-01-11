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
    public bool IsPlayerDetected { get { return playerDetected; } }
    public Vector3 PlayerPosition { get { return playerPosition; } }
    public GameObject Player {  get { return player; } }
    private void Start() {
        agent = GetComponentInParent<NavMeshAgent>();
    }
    private Vector3 directionX, directionY;
    private void Update() {
        if (agent.velocity.x < 0) {
            directionX = Vector3.left;
        } else if (agent.velocity.x > 0) {
            directionX = Vector3.right;
        }
        if (agent.velocity.x >= -0.04 && agent.velocity.x <= 0.04) {
            directionX = Vector3.zero;
        }
        if (agent.velocity.y >= -0.04 && agent.velocity.y <= 0.04) {
            directionY = Vector3.zero;
        }
        if (agent.velocity.y < 0) {
            directionY = Vector3.down;
        } else if (agent.velocity.y > 0) {
            directionY = Vector3.up;
        }
        if (agent.isStopped != true)
            direction = directionX + directionY;
        else
            direction = player.transform.position - transform.position;
    }
    private void FixedUpdate() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 20f, layer);
        Debug.Log(hit.transform.position);
        if (playerDetected != true)
            transform.rotation = Quaternion.LookRotation(agent.velocity);
        else
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