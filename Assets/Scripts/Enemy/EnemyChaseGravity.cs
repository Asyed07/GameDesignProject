using UnityEngine;

public class EnemyChaseGravity : MonoBehaviour
{
    public float moveSpeed = 2f;        // Movement speed of the enemy
    public float jumpHeight = 5f;       // Jump height
    public float detectionRange = 10f;  // Distance from the player at which the enemy starts moving
    public float stopRange = 3f;        // Distance from the player where the enemy stops moving
    public float flipMultiplier = 1f;   // Flip multiplier to control direction
    public float groundCheckDistance = 0.2f;  // Distance to check for ground detection
    public float wallCheckDistance = 0.5f;    // Distance to check for wall detection

    private Rigidbody2D rb;
    private Transform player;
    private bool isGrounded;
    private bool isTouchingWall;
    private float distanceToPlayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform; // Assuming your player is tagged "Player"
    }

    void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Check if the enemy should follow the player or stop
        if (distanceToPlayer < detectionRange)
        {
            FollowPlayer();
        }
        else
        {
            // If not in range, stop moving
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }

        // Check if the enemy should jump
        CheckForJump();

        // Flip the enemy to face the player
        FlipEnemyDirection();

        // Check for wall collision to prevent walking into walls
        CheckForWall();
    }

    void FollowPlayer()
    {
        // If within stop range, stop moving
        if (distanceToPlayer < stopRange)
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            return;
        }

        // Move towards the player, keeping y velocity for gravity
        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = new Vector2(direction.x * moveSpeed, rb.linearVelocity.y);  // Only modify x velocity to move towards player
    }

    void CheckForJump()
    {
        // Simple ground check using raycast to detect if the enemy is grounded
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, LayerMask.GetMask("Ground"));

        if (isGrounded && rb.linearVelocity.y <= 0)
        {
            // Jump when grounded
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
    }

    void FlipEnemyDirection()
    {
        Vector2 direction = player.position - transform.position;

        if (direction.x > 0)  // Player is to the right of the enemy
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * flipMultiplier, transform.localScale.y, transform.localScale.z);
        }
        else if (direction.x < 0)  // Player is to the left of the enemy
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x) * flipMultiplier, transform.localScale.y, transform.localScale.z);
        }
    }

    void CheckForWall()
    {
        // Raycast to detect if there's a wall in front of the enemy (based on the direction the enemy is facing)
        isTouchingWall = Physics2D.Raycast(transform.position, new Vector2(transform.localScale.x, 0), wallCheckDistance, LayerMask.GetMask("Ground"));

        if (isTouchingWall)
        {
            // If the enemy is touching a wall, stop moving
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
    }
}
