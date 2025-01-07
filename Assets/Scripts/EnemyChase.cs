using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script allows an enemy object to chase a player object with some constraints.
public class EnemyChase : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject that the enemy will chase.
    public float speed; // Speed at which the enemy moves towards the player.
    private float distance; // Distance between the enemy and the player.
    public float distanceFromPlayer; // Minimum distance the enemy maintains from the player.

    void Update()
    {
        // Calculate the distance between the enemy and the player.
        distance = Vector2.Distance(transform.position, player.transform.position);

        // Calculate the direction vector from the enemy to the player.
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        // Move the enemy towards the player if it's farther than the specified distance.
        if (distance > distanceFromPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }

        // Determine whether the enemy should face left or right.
        if (direction.x > 0) // Player is to the right of the enemy.
        {
            transform.localScale = new Vector3(-3f, 3f, 1f); // Face right.
        }
        else if (direction.x < 0) // Player is to the left of the enemy.
        {
            transform.localScale = new Vector3(3f, 3f, 1f); // Face left.
        }
    }
}
