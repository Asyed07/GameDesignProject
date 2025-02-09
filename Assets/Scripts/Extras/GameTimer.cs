using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal; // For handling scene events

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;  // Reference to the TextMeshPro UI component
    public TextMeshProUGUI finishTimeText;
    public TextMeshProUGUI bestTimeText;
    public LevelComplete canvasActive;
    private float elapsedTime = 0f;   // Time elapsed since the start of the game
    private float bestTime = 0f;
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
        if (finishTimeText == null)
        {
            // Try finding the TimerText object in the scene
            finishTimeText = GameObject.Find("finishTimeText")?.GetComponent<TextMeshProUGUI>();
        }
        if (bestTimeText == null)
        {
            // Try finding the TimerText object in the scene
            bestTimeText = GameObject.Find("bestTimeText")?.GetComponent<TextMeshProUGUI>();
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
        if (canvasActive != null)
        {
            finishTimeText.text = timerText.text;
            // Store finish time
             // if finish time < best time
            {
                // best time = finish time
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
        finishTimeText = GameObject.Find("finishTimeText")?.GetComponent<TextMeshProUGUI>();
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
