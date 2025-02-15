using UnityEngine;
using TMPro; // Ensure TextMeshPro is used

public class LevelComplete : MonoBehaviour
{
    public GameObject levelCompleteCanvas;
    public TextMeshProUGUI finishTimeText;
    public TextMeshProUGUI bestTimeText;
    public GameTimer gameTimer; // Reference to GameTimer
    public bool canvasActive = false;

    private string levelKey;

    private void Start()
    {
        levelKey = "BestTime_" + UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        // Find the GameTimer object in the scene
        if (gameTimer == null)
        {
            gameTimer = FindFirstObjectByType<GameTimer>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (levelCompleteCanvas != null)
            {
                levelCompleteCanvas.SetActive(true);
                Time.timeScale = 0;
                canvasActive = true;

                if (gameTimer == null)
                {
                    gameTimer = FindFirstObjectByType<GameTimer>(); // Ensure gameTimer is found
                }

                gameTimer.StopTimer();
                float finishTime = gameTimer.GetElapsedTime();

                // Format the finish time
                string formattedFinishTime = FormatTime(finishTime);
                finishTimeText.text = formattedFinishTime;

                // Load best time
                float bestTime = PlayerPrefs.GetFloat(levelKey, float.MaxValue);

                // Only update best time if it's better
                if (finishTime < bestTime)
                {
                    bestTime = finishTime;
                    PlayerPrefs.SetFloat(levelKey, bestTime);
                    PlayerPrefs.Save();
                }

                Debug.Log("Level Key: " + levelKey);
                Debug.Log("Saved Best Time Before Update: " + PlayerPrefs.GetFloat(levelKey, float.MaxValue));
                Debug.Log("Current Finish Time: " + finishTime);
                Debug.Log("Is New Best Time: " + (finishTime < bestTime));

                // Display best time
                bestTimeText.text = FormatTime(bestTime);

                Debug.Log("Finish Time: " + formattedFinishTime);
                Debug.Log("Best Time: " + FormatTime(bestTime));
            }
            else
            {
                Debug.LogWarning("Level complete canvas is not assigned.");
            }
        }
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        int milliseconds = Mathf.FloorToInt((time % 1) * 100);
        return string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }
}
