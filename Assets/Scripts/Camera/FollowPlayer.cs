using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FollowPlayer : MonoBehaviour {
    [SerializeField] private GameObject player;
    private void LateUpdate() {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }
}