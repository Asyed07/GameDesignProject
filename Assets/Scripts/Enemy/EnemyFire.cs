using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject FireBall;
    public Transform FireBallPos;
    public float distanceBetween;
    private float timer;
    private float fireRate = 3;
    private GameObject player;
    private float difficultyMultiplier;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        difficultyMultiplier = PlayerPrefs.GetFloat("DifficultyMultiplier", 1f);
        fireRate = fireRate - (difficultyMultiplier - 1) * 5;
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < distanceBetween)
        {
            timer += Time.deltaTime;
            if (timer > fireRate)
            {
                timer = 0;
                Fire();
            }
        }
    }

    void Fire()
    {
        // Instantiate the fireball
        GameObject fireball = Instantiate(FireBall, FireBallPos.position, Quaternion.identity);

        // Set the fireball's speed based on the enemy's speed
        EnemyFireScript fireballScript = fireball.GetComponent<EnemyFireScript>();
        if (fireballScript != null)
        {
            // Pass the speed of the enemy to the fireball
            fireballScript.SetSpeed(GetComponent<EnemyChase>().speed);
        }
    }
}
