using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobberSprint : MonoBehaviour {
    private RobberMovement robberMovementScript;
    [SerializeField] private float speedWhileSprinting;
    [Header("Cooldown Settings")] //the robber can sprint for a specific amount of time, then he needs to wait for his sprint to refill
    [SerializeField] private float defaultMaxSprint; //for how long can robber sprint
    private float maxSprint;
    [SerializeField] private float defaultCooldownLength; //cooldown for when can his sprint refill while not sprinting
    private float cooldownLength = 0;
    private float sprint;
    public float Sprint { get { return sprint; } }
    public float MaxSprint { get { return maxSprint; } }
    private void Start() {
        if (robberMovementScript == null)
            robberMovementScript = gameObject.GetComponent<RobberMovement>();
        maxSprint = defaultMaxSprint;
        sprint = maxSprint;
    }
    private void Update() {
        if (cooldownLength <= 0 && sprint < maxSprint)
            sprint += Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftShift) && sprint > 0) {
            robberMovementScript.ChangeSpeedTo(speedWhileSprinting);
            sprint -= Time.deltaTime;
            cooldownLength = defaultCooldownLength;
        } else {
            robberMovementScript.ResetSpeed();
            if (cooldownLength > 0)
                cooldownLength -= Time.deltaTime;
        }
    }
}
