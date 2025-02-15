using UnityEngine;
using UnityEngine.SceneManagement;

public class GameProgressManager : MonoBehaviour
{
    private const string LevelKey = "CurrentLevel";
    private const string DifficultyKey = "DifficultySelected";
    private const string FirstTimeKey = "FirstTime";

    public static void SaveLevel(int level)
    {
        PlayerPrefs.SetInt(LevelKey, level);
        PlayerPrefs.Save();
    }

    public static int LoadLevel()
    {
        return PlayerPrefs.GetInt(LevelKey, 1); // Default to level 1
    }

    public static void SaveDifficulty(float difficulty)
    {
        PlayerPrefs.SetFloat(DifficultyKey, difficulty);
        PlayerPrefs.SetInt(FirstTimeKey, 1); // Mark that difficulty was selected
        PlayerPrefs.Save();
    }

    public static float LoadDifficulty()
    {
        return PlayerPrefs.GetFloat(DifficultyKey, 1); // Default to easy
    }

    public static bool IsFirstTime()
    {
        return PlayerPrefs.GetInt(FirstTimeKey, 0) == 0;
    }
    public static float GetTotalBestTime(string[] levelNames)
    {
        float totalBestTime = 0;
        foreach (string level in levelNames)
        {
            totalBestTime += PlayerPrefs.GetFloat("BestTime_" + level, 0);
        }
        return totalBestTime;
    }
}
