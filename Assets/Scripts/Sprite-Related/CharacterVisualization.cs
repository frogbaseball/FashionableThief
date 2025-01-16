using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
public class CharacterVisualization : MonoBehaviour {
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private bool isPlayer;
    [SerializeField] private SpriteRenderer spriteRendererHat;
    private NavMeshAgent agent;
    private SpriteRenderer spriteRenderer;
    private RobberHat robberHatScript;
    private RobberMovement robberMovementScript;
    private Vector3 direction, directionX, directionY;
    private Sprite hat;
    private bool isWearingHat = false;
    [SerializeField] private bool isCitizen = false;
    private float x, y;
    private void Start() {
        if (isPlayer) {
            robberMovementScript = GetComponent<RobberMovement>();
            isWearingHat = true;
            robberHatScript = GetComponent<RobberHat>();
            robberHatScript.ChangeHat(new Hat("Head", null));
        } else {
            agent = GetComponent<NavMeshAgent>();
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update() {
        if (isPlayer) {
            x = robberMovementScript.Direction.x;
            y = robberMovementScript.Direction.y;
            direction = new Direction2D(x, y).Direction;
            if (direction == Vector3.left)
                spriteRenderer.sprite = sprites[0];
            else if (direction == Vector3.right)
                spriteRenderer.sprite = sprites[1];
            else if (direction == Vector3.up)
                spriteRenderer.sprite = sprites[2];
            else if (direction == Vector3.down)
                spriteRenderer.sprite = sprites[3];
        } else {
            if (isCitizen) {
                x = gameObject.GetComponentInChildren<NPCRaycast>().Direction.x;
                y = gameObject.GetComponentInChildren<NPCRaycast>().Direction.y;
            } else {
                x = agent.velocity.x;
                y = agent.velocity.y;
            }
            directionX = new Direction2D(x, y).DirectionX;
            directionY = new Direction2D(x, y).DirectionY;
            if (directionX == Vector3.left)
                spriteRenderer.sprite = sprites[0];
            else if (directionX == Vector3.right)
                spriteRenderer.sprite = sprites[1];
            else if (directionY == Vector3.up)
                spriteRenderer.sprite = sprites[2];
            else if (directionY == Vector3.down)
                spriteRenderer.sprite = sprites[3];
        }
        if (isWearingHat) {
            if (robberHatScript.HatName == "Head")
                return;
            hat = robberHatScript.HatSprite;
            spriteRendererHat.sprite = hat;
        }
    }
}