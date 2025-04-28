using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource audioSource;
    public AudioClip menuMusic;
    public AudioClip[] levelMusic; // Array to store music for different levels

    private void Awake()
    {
        // Check only one AudioManager exists in the scene
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Stay across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate AudioManagers in the scene
        }
    }

    public void PlayLevelMusic(int levelIndex)
    {
        if (levelIndex >= 0 && levelIndex < levelMusic.Length)
        {
            audioSource.clip = levelMusic[levelIndex];
            audioSource.Play();
        }
    }

    // Play menu music
    public void PlayMenuMusic()
    {
        audioSource.clip = menuMusic;
        audioSource.Play();
    }

    // Adjust the volume of the music
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Play appropriate music based on the scene
        if (scene.buildIndex == 0) // Main menu scene index 0
        {
            PlayMenuMusic();
        }
        else
        {
            PlayLevelMusic(scene.buildIndex - 1); // Level scenes are indexed starting from 1
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
