using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float flightSpeed = 0.5f;
    public float dashSpeed = 2f;
    public float playerHealth = 10f;

    public Animator myAnimator;
    public Rigidbody2D myRigidbody;
    public SpriteRenderer mySpriteRenderer;

    public BoxCollider2D collisionDetector; // Ground check using a collider

    public bool playerIsAlive = true;
    private bool isDashing = false;



    void Update()
    {
        // --- Toggle Dash ---
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isDashing = !isDashing;
        }

        // --- horizontal Movement input ---
        float moveXDirection = 0f;
        if (Input.GetKey(KeyCode.W)) moveXDirection = 1f;
        if (Input.GetKey(KeyCode.S)) moveXDirection = -1f;

        // --- speed ---
        float currentXSpeed = isDashing ? dashSpeed : flightSpeed;

        // --- Apply movement ---
        myRigidbody.linearVelocity = new Vector2(moveXDirection * currentXSpeed, myRigidbody.linearVelocity.y);

        // --- Vertical Movement input ---
        float moveYDirection = 0f;
        if (Input.GetKey(KeyCode.D)) moveYDirection = 1f;
        if (Input.GetKey(KeyCode.A)) moveYDirection = -1f;

        // --- speed ---
        float currentYSpeed = isDashing ? dashSpeed : flightSpeed;

        // --- Apply movement ---
        myRigidbody.linearVelocity = new Vector2(moveYDirection * currentYSpeed, myRigidbody.linearVelocity.x);
    }
}
