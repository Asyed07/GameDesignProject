using UnityEngine;

public class Player : MonoBehaviour
{
    public int MaxHealth = 100;
    public int Health;

    public HealthBar HBar;

    void Start()
    {
        Health = MaxHealth;
        HBar.SetMaxHealth(MaxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DamageTaken(5);
        }
    }

    void DamageTaken(int damage)
    {
        Health -= damage;
        HBar.SetHealth(Health);
    }
}