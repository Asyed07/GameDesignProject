using UnityEngine;

public class Player : MonoBehaviour
{
    public int MaxHealth = 20;
    public int Health;

    public HealthBar HBar;
    public int attackDamage = 5; // The damage the player deals to the enemy
    public Animator animator;
    public float attackCooldown = 0.5f; // Time in seconds before another attack can be triggered
    private float lastAttackTime = 0f;

    // Reference to the Game Over screen UI
    public GameObject GameOverScreen;

    private bool isAttacking = false;

    private void Start()
    {
        Health = MaxHealth;
        HBar.SetMaxHealth(MaxHealth);

        // Ensure Game Over screen is initially disabled
        if (GameOverScreen != null)
        {
            GameOverScreen.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            DamageTaken(1);
        }

        // Attack on Q or Left Click
        if ((Input.GetKeyDown(KeyCode.Q) || Input.GetMouseButtonDown(0)) && !isAttacking)
        {
            Attack();
        }
    }

    void DamageTaken(int damage)
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
        // Only trigger the attack if enough time has passed since the last attack
        if (Time.time - lastAttackTime >= attackCooldown && !isAttacking)
        {
            lastAttackTime = Time.time; // Update the last attack time
            isAttacking = true;
            animator.SetBool("IsAttacking", true); // Trigger attack animation
        }

        LayerMask enemyLayer = LayerMask.GetMask("Enemy");

        // (Optional) Perform raycast and deal damage if needed
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 1f, enemyLayer);

        Debug.DrawRay(transform.position, transform.right * 1f, Color.red, 1f); // Visualize the ray

        if (hit.collider != null)
        {
            // Only trigger damage if the ray hits an object tagged as "Enemy"
            if (hit.collider.CompareTag("Enemy"))
            {
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(attackDamage);
                }
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
