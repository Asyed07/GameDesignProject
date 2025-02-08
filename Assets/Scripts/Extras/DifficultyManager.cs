using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyManager : MonoBehaviour
{
    public void SetDifficulty(string difficulty)
    {
        float multiplier = 1f; // Default Easy

        switch (difficulty)
        {
            case "Easy":
                multiplier = 1f;
                break;
            case "Medium":
                multiplier = 1.2f;
                break;
            case "Hard":
                multiplier = 1.3f;
                break;
        }

        PlayerPrefs.SetString("SelectedDifficulty", difficulty);
        PlayerPrefs.SetFloat("DifficultyMultiplier", multiplier);
        PlayerPrefs.SetInt("FirstTime", 1); // Mark that difficulty was selected
        PlayerPrefs.Save();

        // Load the first level after selecting difficulty
        SceneManager.LoadScene("Level1");
    }
}
