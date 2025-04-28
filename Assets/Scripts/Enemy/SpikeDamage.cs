using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    public float damageAmount = 999999f; // How much damage to deal on contact
    public string playerTag = "Player";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag)) // Check if player collided
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.DamageTaken(damageAmount); // Damage Player
            }
        }
    }
}
