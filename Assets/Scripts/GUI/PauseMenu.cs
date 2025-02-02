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
        if (Input.GetKeyUp(KeyCode.R))
        {
            if (Time.timeScale == 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
        Time.timeScale = 1;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1; // Unpauses the game
        isPaused = false;
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Restarts the level selected
        Time.timeScale = 1;
    }
}
