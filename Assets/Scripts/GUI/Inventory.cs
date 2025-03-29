using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject inventory;

    private bool inventoryisClosed = true;

    void Update()
    {
        // Only allow inventory toggle if the game is not paused
        if (Time.timeScale > 0 && Input.GetKeyDown(KeyCode.E))
        {
            if (inventoryisClosed)
            {
                OpenInventory();
            }
            else
            {
                CloseInventory();
            }
        }
    }

    public void OpenInventory()
    {
        inventory.SetActive(true);
        inventoryisClosed = false;
    }

    public void CloseInventory()
    {
        inventory.SetActive(false);
        inventoryisClosed = true;
    }
}