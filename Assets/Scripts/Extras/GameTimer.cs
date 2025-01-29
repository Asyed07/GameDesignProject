using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // For handling scene events

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;  // Reference to the TextMeshPro UI component
    private float elapsedTime = 0f;   // Time elapsed since the start of the game
    private bool isTimerRunning = true;

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
            // Try finding the TimerText object in the scene
            timerText = GameObject.Find("TimerText")?.GetComponent<TextMeshProUGUI>();
        }
    }

    void Update()
    {
        if (isTimerRunning)
        {
            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            // Convert elapsed time to minutes, seconds, and milliseconds
            int minutes = Mathf.FloorToInt((elapsedTime % 3600) / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            int milliseconds = Mathf.FloorToInt((elapsedTime % 1) * 100);

            // Update the TextMeshPro timer text
            if (timerText != null)
            {
                timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
            }
        }
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public void StartTimer()
    {
        isTimerRunning = true;
    }

    public void ResetTimer()
    {
        elapsedTime = 0f;
        isTimerRunning = true;
    }

    public void ResetTimerForSceneReload()
    {
        elapsedTime = 0f;    // Reset the elapsed time
        isTimerRunning = true;

        // Reassign timerText in case the UI is reloaded in the new scene
        timerText = GameObject.Find("TimerText")?.GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reset the timer whenever the scene is reloaded
        ResetTimerForSceneReload();
    }

}
