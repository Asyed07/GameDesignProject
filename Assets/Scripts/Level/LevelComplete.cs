using UnityEngine;
using TMPro; // For using TextMeshPro UI components

public class LevelComplete : MonoBehaviour
{

    public GameObject levelCompleteUI; // Reference to the UI object that appears when the level is completed
    public TextMeshProUGUI finishTimeText; // Reference to the TextMeshProUGUI component that displays the player's finish time
    public TextMeshProUGUI bestTimeText; // Reference to the TextMeshProUGUI component that displays the best recorded time
    public bool canvasActive = false; // Tracks whether the level complete screen is currently active
    public GameTimer gameTimer;
    private string levelKey; // Key used for storing the best time for the current level from PlayerPrefs

    private void Start()
    {
        // Generate a unique key based on the scene name to store the best time for this specific level
        levelKey = "BestTime_" + UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        // Find gameTimer in the scene if it's missing from the inspector
        if (gameTimer == null)
        {
            gameTimer = FindFirstObjectByType<GameTimer>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if object entering the trigger has the player tag
        if (other.CompareTag("Player"))
        {
            if (levelCompleteUI != null)
            {
                levelCompleteUI.SetActive(true); // Activate the level complete UI
                canvasActive = true;
                Time.timeScale = 0; // Pause game

                if (gameTimer == null)
                {
                    gameTimer = FindFirstObjectByType<GameTimer>();
                }

                gameTimer.StopTimer();
                float finishTime = gameTimer.GetElapsedTime(); // Get the time the player took to complete the level
                string formattedFinishTime = FormatTime(finishTime); // Format and display the finish time
                finishTimeText.text = formattedFinishTime;
                float bestTime = PlayerPrefs.GetFloat(levelKey, float.MaxValue); // Retrieve the best time from PlayerPrefs, using float.MaxValue as the default

                // If the player's finish time is better than the saved best time, update it
                if (finishTime < bestTime)
                {
                    bestTime = finishTime;
                    PlayerPrefs.SetFloat(levelKey, bestTime); // Save new best time
                    PlayerPrefs.Save(); // Ensure changes are written to disk
                }

                bestTimeText.text = FormatTime(bestTime); // Format and display the best time
            }
        }
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60); // Get whole minutes
        int seconds = Mathf.FloorToInt(time % 60); // Get remaining seconds
        int milliseconds = Mathf.FloorToInt((time % 1) * 100); // Get milliseconds as two digits

        // Return formatted string like "01:23:45"
        return string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }
}
