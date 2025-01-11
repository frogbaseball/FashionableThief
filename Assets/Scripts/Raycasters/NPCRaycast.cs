using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NPCRaycast : MonoBehaviour {
    [SerializeField] private LayerMask layer;
    private bool playerDetected = false;
    private Vector3 playerPosition;
    private GameObject player;
    public bool IsPlayerDetected { get { return playerDetected; } }
    public Vector3 PlayerPosition { get { return playerPosition; } }
    public GameObject Player {  get { return player; } }
    private void FixedUpdate() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 20f, layer);
        try {
            hit.collider.GetComponent<RobberHat>();
            playerDetected = true;
            playerPosition = hit.point;
            player = hit.collider.gameObject;
        } catch {
            playerDetected = false;
        }

    }
}