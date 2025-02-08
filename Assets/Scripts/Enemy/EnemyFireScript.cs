using UnityEngine;

public class EnemyFireScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rigidBody;
    private int FireDamage = 5;
    private float force = 3;
    private float timer;
    private float difficultyMultiplier;
    public float speed { get; private set; }

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        difficultyMultiplier = PlayerPrefs.GetFloat("DifficultyMultiplier", 1f);
        if (player != null)
        {
            Vector3 direction = player.transform.position - transform.position;
            rigidBody.linearVelocity = new Vector2(direction.x, direction.y).normalized * force * Mathf.Pow(difficultyMultiplier, 2);
            float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot + 180);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 6)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player playerScript = other.gameObject.GetComponent<Player>();
            if (playerScript != null)
            {
                playerScript.DamageTaken(FireDamage + (difficultyMultiplier - 1) * 20);
            }
            Destroy(gameObject);
        }
    }
}