using UnityEngine;

public class ItemRotator : MonoBehaviour
{
    public float rotationSpeed = 30f; // Degrees per second

    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (rectTransform != null)
        {
            rectTransform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}
