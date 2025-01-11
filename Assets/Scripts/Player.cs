using UnityEngine;

public class Player : MonoBehaviour
{
    public int MaxHealth = 20;
    public int Health;

    public HealthBar HBar;

    // Reference to the Game Over screen UI
    public GameObject GameOverScreen;

    void Start()
    {
        Health = MaxHealth;
        HBar.SetMaxHealth(MaxHealth);

        // Ensure Game Over screen is initially disabled
        if (GameOverScreen != null)
        {
            GameOverScreen.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            DamageTaken(1);
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
}
