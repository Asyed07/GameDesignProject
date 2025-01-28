using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemsCollected : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    private int itemsCollected = 0;
    public int totalItems = 3;

    private void Start()
    {
        counterText.text = ": " + itemsCollected + " / " + totalItems;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            itemsCollected = +itemsCollected;
            counterText.text = ": " + itemsCollected + " / " + totalItems;
            Destroy(collision.gameObject);
        }
    }
}