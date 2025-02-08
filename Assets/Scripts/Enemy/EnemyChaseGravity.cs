using UnityEngine;

public class EnemyChaseGravity : MonoBehaviour
{
    private float moveSpeed = 4f;        // Movement speed of the enemy
    public float detectionRange = 10f;  // Distance from the player at which the enemy starts moving
    public float stopRange = 3f;        // Distance from the player where the enemy stops moving
    public float flipMultiplier = 1f;   // Flip multiplier to control direction
    private float difficultyMultiplier;
    private Rigidbody2D rb;
    private Transform player;
    private float distanceToPlayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform; // Assuming your player is tagged "Player"
        difficultyMultiplier = PlayerPrefs.GetFloat("DifficultyMultiplier", 1f);
        moveSpeed = moveSpeed + (difficultyMultiplier - 1) * 10;
        detectionRange = detectionRange + (difficultyMultiplier - 1 ) * 10;
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
        // Flip the enemy to face the player
        FlipEnemyDirection();
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
}
