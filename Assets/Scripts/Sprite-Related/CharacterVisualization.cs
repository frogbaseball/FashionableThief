using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
public class CharacterVisualization : MonoBehaviour {
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private bool isPlayer;
    private NavMeshAgent agent;
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer spriteRendererHat;
    private RobberHat robberHatScript;
    private RobberMovement robberMovementScript;
    private Vector3 direction;
    private Sprite hat;
    private bool isWearingHat = false;
    private float x, y;
    private void Start() {
        if (isPlayer) {
            robberMovementScript = GetComponent<RobberMovement>();
            isWearingHat = true;
            robberHatScript = GetComponent<RobberHat>();
            robberHatScript.ChangeHat(new Hat("Head", ""));
            spriteRendererHat = GetComponentInChildren<SpriteRenderer>();
        } else {
            agent = GetComponent<NavMeshAgent>();
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update() {
        if (isPlayer) {
            x = robberMovementScript.Direction.x;
            y = robberMovementScript.Direction.y;
        } else {
            x = agent.velocity.x;
            y = agent.velocity.y;
        }
        direction = new Direction2D(x, y).Direction;
        if (direction == Vector3.left)
            spriteRenderer.sprite = sprites[0];
        else if (direction == Vector3.right)
            spriteRenderer.sprite = sprites[1];
        else if (direction == Vector3.up)
            spriteRenderer.sprite = sprites[2];
        else if (direction == Vector3.down)
            spriteRenderer.sprite = sprites[3];
        if (isWearingHat) {
            if (robberHatScript.HatName == "Head")
                return;
            hat = AssetDatabase.LoadAssetAtPath<Sprite>(robberHatScript.HatPath);
            spriteRendererHat.sprite = hat;
        }
    }
}