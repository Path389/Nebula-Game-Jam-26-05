using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public float flightSpeed = 0.5f;
    public float dashSpeed = 2f;
    public float playerHealth = 10f;

    public Animator myAnimator;
    public Rigidbody2D myRigidbody;
    public SpriteRenderer mySpriteRenderer;
    public PlayerInventory playerInventory;

    public BoxCollider2D collisionDetector; // Ground check using a collider

    public bool playerIsAlive = true;
    private bool isDashing = false;

    private Vector2 direction;
    



    void Update()
    {
        //rotates to face the mouse
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;

        // --- Toggle Dash ---
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isDashing = !isDashing;
        }
        // --- speed ---
        float currentXSpeed = isDashing ? dashSpeed : flightSpeed * playerInventory.SpeedLvl;
        float currentYSpeed = isDashing ? dashSpeed : flightSpeed * playerInventory.SpeedLvl;

        // --- Apply movement ---

        Movement(currentXSpeed, currentYSpeed);
    }

    void Movement(float currentXSpeed, float currentYSpeed)
    {
        Vector2 inputDir = Vector2.zero;

        if (Input.GetKey(KeyCode.A)) inputDir.x -= 1; // Left
        else if (Input.GetKey(KeyCode.D)) inputDir.x += 1; // Right
        if (Input.GetKey(KeyCode.W)) inputDir.y += 1; // Forward
        else if (Input.GetKey(KeyCode.S)) inputDir.y -= 1; // Backward
  

        float angle = transform.eulerAngles.z;

        // Rotate inputDir by head angle
        Vector2 direction = Quaternion.Euler(0, 0, angle) * inputDir;
        direction.Normalize();

        myRigidbody.linearVelocity = new Vector2(direction.x * currentXSpeed, direction.y * currentYSpeed);
    }
}
