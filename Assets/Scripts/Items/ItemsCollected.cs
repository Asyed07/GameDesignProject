using UnityEngine;
using TMPro;

public class ItemsCollected : MonoBehaviour
{
    public TextMeshProUGUI counterText;  // Reference to the TextMeshPro UI component
    private int itemsCollected = 0;     // Number of items collected by the player
    public int totalItems = 3;          // Total items to collect

    private void Start()
    {
        // Initialize the counter display
        UpdateCounterText();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            // Check if the item has already been collected
            CollectibleItem item = collision.GetComponent<CollectibleItem>();
            if (item != null && item.Collect())
            {
                Destroy(collision.gameObject); // Destroy the collected item
                itemsCollected++;             // Increment the collected item count
                UpdateCounterText();
            }
        }
    }

    private void UpdateCounterText()
    {
        // Update the counter display text
        counterText.text = ": " + itemsCollected + " / " + totalItems;
    }
}
