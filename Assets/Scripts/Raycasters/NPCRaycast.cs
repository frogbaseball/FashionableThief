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
    [SerializeField] private bool suspisionMechanic;
    [SerializeField] private float maxSuspision;
    [SerializeField] private GameObject suspisionLevel;
    [SerializeField] private Sprite[] suspisionSprites;
    private NavMeshAgent agent;
    private bool playerDetected = false;
    private Vector3 playerPosition;
    private GameObject player;
    private Vector3 direction;
    private Direction2D direction2D;
    public float Suspision;
    public Vector3 Direction { get { return direction; } }
    public bool IsPlayerDetected { get { return playerDetected; } }
    public Vector3 PlayerPosition { get { return playerPosition; } }
    public GameObject Player {  get { return player; } }
    public float MaxSuspision { get { return maxSuspision; } }
    private void Start() {
        agent = GetComponentInParent<NavMeshAgent>();
    }
    private void Update() {
        if (Suspision >= 0 && suspisionMechanic) {
            suspisionLevel.transform.localScale = new Vector3(Suspision / 2, Suspision / 2, 1);
            if (Suspision >= maxSuspision - 0.1f) {
                suspisionLevel.GetComponent<SpriteRenderer>().color = Color.red;
                suspisionLevel.GetComponent<SpriteRenderer>().sprite = suspisionSprites[1];
            } else {
                suspisionLevel.GetComponent<SpriteRenderer>().color = Color.white;
                suspisionLevel.GetComponent<SpriteRenderer>().sprite = suspisionSprites[0];
            }
        }
        if (!agent.isStopped && (agent.desiredVelocity.x != 0 && agent.desiredVelocity.y != 0))
            direction2D = new Direction2D(agent.desiredVelocity.x, agent.desiredVelocity.y);
        if (!agent.isStopped)
            direction = direction2D.Direction;
        else
            direction = player.transform.position - transform.position;
    }
    private void FixedUpdate() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 20f, layer);
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