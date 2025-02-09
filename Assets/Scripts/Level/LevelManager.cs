using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void OnLevelCompleted(int nextLevel)
    {
        GameProgressManager.SaveLevel(nextLevel);
    }
}
