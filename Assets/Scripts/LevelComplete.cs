using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public GameObject levelCompleteCanvas;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debugging: Check if the player is entering the trigger
        Debug.Log("Trigger entered by: " + other.gameObject.name);

        // Check if the object colliding with the trigger is the player
        if (other.CompareTag("Player"))
        {
            // Debugging: Confirm that the player triggered the event
            Debug.Log("Player reached the trigger");

            // Activate the level complete canvas
            if (levelCompleteCanvas != null)
            {
                levelCompleteCanvas.SetActive(true);
            }
            else
            {
                Debug.LogWarning("Level complete canvas is not assigned.");
            }
        }
    }
}
