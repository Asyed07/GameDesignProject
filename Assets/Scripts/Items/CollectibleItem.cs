using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    private bool isCollected = false;

    public bool Collect()
    {
        if (isCollected) return false; // If already collected, do nothing
        isCollected = true;
        return true;
    }
}