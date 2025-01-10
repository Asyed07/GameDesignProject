using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int MaxEnemyHealth = 20;
    public int Enemyhealth;

    public EnemyHealth enemyHealth;

    void Start()
    {
        Enemyhealth = MaxEnemyHealth;
        enemyHealth.SetMaxHealth(MaxEnemyHealth);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            EnemyDamage(1);
        }
    }
    void EnemyDamage(int damage)
    {
        Enemyhealth -= damage;
        enemyHealth.SetHealth(Enemyhealth);
    }
}