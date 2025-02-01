using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyManager : MonoBehaviour
{
    public void SelectDifficulty(float difficulty)
    {
        GameProgressManager.SaveDifficulty(difficulty);
        SceneManager.LoadScene("Level1"); // Load the first level
    }
}
