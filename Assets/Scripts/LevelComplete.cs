using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public GameObject levelCompleteCanvas;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object colliding with the trigger is the player
        if (other.CompareTag("Player"))
        {
            // Activate the level complete canvas
            if (levelCompleteCanvas != null)
            {
                levelCompleteCanvas.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                Debug.LogWarning("Level complete canvas is not assigned.");
            }
        }
    }
}
