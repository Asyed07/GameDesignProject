using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;
    [SerializeField] private Vector2 positionValues;
    private Vector2 cursorHotspot;

    void Start()
    {
        cursorHotspot = positionValues;
        Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
    }
}
