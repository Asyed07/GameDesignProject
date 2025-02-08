using UnityEngine;

public class EnemyFireScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rigidBody;
    public int FireDamage;
    public float force;
    private float timer;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            Vector3 direction = player.transform.position - transform.position;
            rigidBody.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;
            float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot + 180);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 10)
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
                playerScript.DamageTaken(FireDamage);
            }
            Destroy(gameObject);
        }
    }
}
