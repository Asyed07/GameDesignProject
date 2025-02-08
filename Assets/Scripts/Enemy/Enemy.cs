using UnityEngine;
using System.Collections; // Required for Coroutines

public class Enemy : MonoBehaviour
{
    public float MaxEnemyHealth = 40;
    public float EnemyHealth;
    public float EnemyAttackDamage = 5;
    public EnemyHealth enemyHealth;
    private float difficultyMultiplier;
    private bool isPlayerInContact = false; // Track player contact

    private void Start()
    {
        difficultyMultiplier = PlayerPrefs.GetFloat("DifficultyMultiplier", 1f);
        MaxEnemyHealth = MaxEnemyHealth * difficultyMultiplier;
        EnemyAttackDamage = EnemyAttackDamage * Mathf.Pow(difficultyMultiplier, 3);
        EnemyHealth = MaxEnemyHealth;
        enemyHealth.SetMaxHealth(MaxEnemyHealth);
    }

    public void TakeDamage(float damage)
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
        gameObject.SetActive(false); // Temporarily disable the enemy
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isPlayerInContact)
        {
            isPlayerInContact = true;
            StartCoroutine(DamagePlayerOverTime(collision.gameObject.GetComponent<Player>()));
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInContact = false;
        }
    }

    private IEnumerator DamagePlayerOverTime(Player player)
    {
        while (isPlayerInContact && player.Health > 0)
        {
            player.DamageTaken(EnemyAttackDamage);
            yield return new WaitForSeconds(1f); // Damage every 1 second
        }
    }
}
