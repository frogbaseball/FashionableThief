using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RobberMovement : MonoBehaviour {
    private Vector2 direction = Vector2.zero;
    private int x, y;
    [SerializeField] private float defaultSpeed;
    private float speed;
    private void Start() {
        ResetSpeed();
    }
    private void Update() {
        if (Input.GetKey(KeyCode.A))
            x = -1;
        else if (Input.GetKey(KeyCode.D))
            x = 1;
        else
            x = 0;
        if (Input.GetKey(KeyCode.S))
            y = -1;
        else if (Input.GetKey(KeyCode.W))
            y = 1;
        else
            y = 0;
        direction = Vector2.up * y + Vector2.right * x;
    }
    private void FixedUpdate() {
        transform.position += (Vector3)direction * speed * Time.fixedDeltaTime;
    }
    public void ChangeSpeedTo(float newSpeed) {
        speed = newSpeed;
    }
    public void ResetSpeed() {
        speed = defaultSpeed;
    }
}