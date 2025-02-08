using TMPro.Examples;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject FireBall;
    public Transform FireBallPos;
    public float distanceBetween;
    private float timer;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < distanceBetween)
        {
            timer += Time.deltaTime;
            if (timer > 2)
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
