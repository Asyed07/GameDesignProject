using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal; // For handling scene events

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;  // Reference to the TextMeshPro UI component
    public LevelComplete canvasActive;
    private float elapsedTime = 0f;   // Time elapsed since the start of the game
    private bool isTimerRunning = true; // Keeps track of whether timer is runnning or not

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
            // Find the TimerText object in the scene if it isn't already found
            timerText = GameObject.Find("TimerText")?.GetComponent<TextMeshProUGUI>();
        }
    }

    void Update()
    {
        if (isTimerRunning)
        {
            elapsedTime += Time.deltaTime; // Increment the elapsed time

            // Convert elapsed time to minutes, seconds, and milliseconds
            int minutes = Mathf.FloorToInt((elapsedTime % 3600) / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            int milliseconds = Mathf.FloorToInt((elapsedTime % 1) * 100);

            // Update the TextMeshPro timer text in the correct format
            if (timerText != null)
            {
                timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
            }
        }
    }

    public void StopTimer()
    {
        isTimerRunning = false; // 
    }

    public void StartTimer()
    {
        isTimerRunning = true;
    }

    public void ResetTimer()
    {
        elapsedTime = 0f; // Reset elapsed time
        isTimerRunning = true;

        timerText = GameObject.Find("TimerText")?.GetComponent<TextMeshProUGUI>();
        if (timerText != null)
        {
            timerText.text = "00:00:00"; // Reset timer text to 0
        }
    }

    public void ResetTimerForSceneReload()
    {
        elapsedTime = 0f; // Reset the elapsed time
        isTimerRunning = true; // Ensure scene starts with timer running

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
    public float GetElapsedTime()
    {
        return elapsedTime;
    }
}
