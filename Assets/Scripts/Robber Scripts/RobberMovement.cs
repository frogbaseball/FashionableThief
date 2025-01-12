using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RobberMovement : MonoBehaviour {
    private Vector2 direction = Vector2.zero;
    private Rigidbody2D rb2D;
    public Vector2 Direction { get { return direction; } }
    private int x, y;
    [SerializeField] private float defaultSpeed;
    private float speed;
    private void Start() {
        ResetSpeed();
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void Update() {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            x = -1;
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            x = 1;
        else
            x = 0;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            y = -1;
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            y = 1;
        else
            y = 0;
        direction = Vector2.up * y + Vector2.right * x;
    }
    private void FixedUpdate() {
        rb2D.AddForce(direction.normalized * speed * Time.fixedDeltaTime);
    }
    public void ChangeSpeedTo(float newSpeed) {
        speed = newSpeed;
    }
    public void ResetSpeed() {
        speed = defaultSpeed;
    }
}