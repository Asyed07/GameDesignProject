using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int MaxEnemyHealth = 40;
    public int EnemyHealth;
    public int EnemyAttackDamage = 5;
    public EnemyHealth enemyHealth;

    private void Start()
    {
        EnemyHealth = MaxEnemyHealth;
        enemyHealth.SetMaxHealth(MaxEnemyHealth);
    }

    public void TakeDamage(int damage)
    {
        EnemyHealth -= damage;
        enemyHealth.SetHealth(EnemyHealth);

        if (EnemyHealth <= 0)
        {
            DestroyEnemy();
        }
    }

    void DestroyEnemy()
    {
        // Implement enemy death behavior, such as playing a death animation, disabling the enemy, etc.
        gameObject.SetActive(false); // Temporarily disable the enemy
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.DamageTaken(EnemyAttackDamage);
            }
        }
    }
}
