using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damageAmount = 10;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Health playerHealth = collision.gameObject.GetComponent<Health>();

            if (playerHealth != null)
            { 
                playerHealth.TakeDamge(damageAmount);
            }
        }
    }
}
