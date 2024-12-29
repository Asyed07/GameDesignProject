using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float distance;
    public float distanceBetween; 
    
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Matf.Atan2(direction.y, direction.x) * mathf.Rad2Deg;

        if (distance > distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transformation.rotation = Quaternion.Euler(Vector3.forward * angle);
        }

        if ( >= 0.01f)
        {
            transform.localScale = new vector3(-1f, 1f, 1f);
        }
        else if ( <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}