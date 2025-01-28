using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;  // Reference to the UI Text component
    private float elapsedTime = 0f;  // Time elapsed since the start of the game
    private bool isTimerRunning = true;  // Controls whether the timer is active

    private static GameTimer instance;  // Singleton instance for persistence

    private void Awake()
    {
        // Ensure only one instance of the GameTimer exists
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Make this object persist across scenes
        }
    }

    void Start()
    {
        if (timerText == null)
        {
            // If the Text UI isn't assigned, try finding it in the scene
            timerText = GameObject.Find("TimerText")?.GetComponent<TextMeshProUGUI>();
        }
    }

    void Update()
    {
        if (isTimerRunning)
        {
            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            // Convert elapsed time to minutes and seconds
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);

            // Update the timer text if it's available
            if (timerText != null)
            {
                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
        }
    }

    // Public method to stop the timer
    public void StopTimer()
    {
        isTimerRunning = false;
    }

    // Public method to start the timer
    public void StartTimer()
    {
        isTimerRunning = true;
    }

    // Public method to reset the timer
    public void ResetTimer()
    {
        elapsedTime = 0f;
        isTimerRunning = true;
    }
}