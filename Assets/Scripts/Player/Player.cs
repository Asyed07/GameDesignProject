using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MaxHealth = 75;
    public float Health = 75;
    public HealthBar HBar;
    private float attackDamage = 7; // The damage the player deals to the enemy
    public Animator animator;
    private float difficultyMultiplier;
    private bool Healing = false;
    // Reference to the Game Over screen UI
    public GameObject GameOverScreen;

    private bool isAttacking = false;

    private void Start()
    {
        difficultyMultiplier = PlayerPrefs.GetFloat("DifficultyMultiplier", 1f);
        MaxHealth = MaxHealth * difficultyMultiplier;
        Health = MaxHealth;
        HBar.SetMaxHealth(MaxHealth);

        // Ensure Game Over screen is initially disabled
        if (GameOverScreen != null)
        {
            GameOverScreen.SetActive(false);
        }

        StartCoroutine(HealthRegen());
    }

    private IEnumerator HealthRegen()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);

            if (Health < MaxHealth)
            {
                if (Healing != false)
                {
                    Health += 5 - (difficultyMultiplier - 1) * 10;
                    HBar.SetHealth(Health);
                }
            }
        }
    }

    private void Update()
    {
        // Attack on Q or Left Click
        if ((Input.GetKeyDown(KeyCode.Q) || Input.GetMouseButtonDown(0)) && !isAttacking && Time.timeScale != 0)
        {
            Attack();
        }
    }

    public void DamageTaken(float damage)
    {
        Health -= damage;
        HBar.SetHealth(Health);

        // Check if health has reached zero
        if (Health <= 0)
        {
            Health = 0; // Clamp health to zero
            TriggerGameOver();
        }
    }
    void Attack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            animator.SetBool("IsAttacking", true);
        }

        // Define the origin of the boxcast
        Vector2 attackOrigin = new Vector2(transform.position.x, (float)(transform.position.y - 0.5));

        // Define the size of the box (width and height)
        Vector2 boxSize = new Vector2(1.5f, 0.5f); // Adjust these values for width and height

        // Flip the direction based on the player's facing direction
        Vector2 raycastDirection = Vector2.right * Mathf.Sign(transform.localScale.x);

        // Perform the BoxCast
        RaycastHit2D hit = Physics2D.BoxCast(
            attackOrigin,      // Origin of the box
            boxSize,           // Size of the box (width, height)
            0f,                // Angle of the box (0 means no rotation)
            raycastDirection,  // Direction of the box
            1f,                // Distance the box moves
            LayerMask.GetMask("Enemy") // Optional: Filter by layers
        );

        // Debug the BoxCast in the Scene view
        Debug.DrawRay(attackOrigin, raycastDirection * 1f, Color.red, 0.1f); // Visualize center ray
        Debug.DrawRay(attackOrigin + new Vector2(0, boxSize.y / 2), raycastDirection * 1f, Color.red, 0.1f); // Top edge
        Debug.DrawRay(attackOrigin - new Vector2(0, boxSize.y / 2), raycastDirection * 1f, Color.red, 0.1f); // Bottom edge

        if (hit.collider != null && hit.collider.CompareTag("Enemy"))
        {
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(attackDamage - (difficultyMultiplier - 1) * 10);
            }
        }
    }




    void TriggerGameOver()
    {
        // Activate the Game Over screen
        if (GameOverScreen != null)
        {
            GameOverScreen.SetActive(true);
        }

        // Optionally, you could stop player input or the game entirely
        Time.timeScale = 0; // Pause the game
    }

    // Reset the attack animation state once the attack animation finishes
    public void OnAttackAnimationComplete()
    {
        isAttacking = false;
        animator.SetBool("IsAttacking", false); // Reset the attack animation
    }
}
