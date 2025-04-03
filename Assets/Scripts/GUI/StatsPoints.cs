using UnityEditor;
using UnityEngine;

public class StatsPoints
{
    public static StatsPoints Instance { get; private set; }
    private int Points = 0;
    private int LevelStartPoints = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveLevelStartPoints()
    {
        LevelStartPoints = Points;
    }

    public void RestartPoints()
    {
        Points = LevelStartPoints;
    }
    public void ResetProgress()
    {
        Points = 0;
        LevelStartPoints = 0;
    }

    public int GetPoints()
    {
        return Points;
    }
}
