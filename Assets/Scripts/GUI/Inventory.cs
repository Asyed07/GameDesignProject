using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject inventory;

    private bool inventoryisClosed = true;
    private bool isPaused = false;

    void Update()
    {
        // Only allow inventory toggle if the game is not paused
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inventoryisClosed)
            {
                if (!isPaused)
                OpenInventory();
            }
            else
            {
                CloseInventory();
            }
        }
    }
    public void Resume()
    {
        inventory.SetActive(false);
        inventoryisClosed = true;
        Time.timeScale = 1; // Unpauses the game
        isPaused = false;
    }

    public void OpenInventory()
    {
        Time.timeScale = 0;
        isPaused = true;
        inventory.SetActive(true);
        inventoryisClosed = false;
    }

    public void CloseInventory()
    {
        isPaused = false;
        Time .timeScale = 1;
        inventory.SetActive(false);
        inventoryisClosed = true;
    }
}