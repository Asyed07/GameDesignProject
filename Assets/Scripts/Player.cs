using UnityEngine;

public class Player : MonoBehaviour
{
    public int MaxHealth = 20;
    public int Health;

    public HealthBar HBar;

    void Start()
    {
        Health = MaxHealth;
        HBar.SetMaxHealth(MaxHealth);
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
    }
}