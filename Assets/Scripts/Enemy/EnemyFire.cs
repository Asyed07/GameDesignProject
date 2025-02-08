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
        Instantiate(FireBall, FireBallPos.position, Quaternion.identity);
    }
}