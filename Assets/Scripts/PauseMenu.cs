using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    private bool isPaused = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0; // Pauses the game while the pause menu is open
        isPaused = true;
    }

    public void Home()
    {
        SceneManager.LoadScene("Menu");    // Goes to the main menu
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1; // Unpauses the game
        isPaused = false;
    }


    public void Restart(string sceneName)
    {
        SceneManager.LoadScene(sceneName);  // Restarts the level selected
        Time.timeScale = 1;
    }
}
