using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void Pause()
    {
         pauseMenu.SetActive(true);
        Time.timeScale = 0; // Pauses the game while the pause menu is open
    }

    public void Home()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1; // Unpauses the game while the pause menu is open
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1; // Unpauses the game while the pause menu is open
    }

    
    public void Restart(string sceneName)
    {
        SceneManager.LoadScene(sceneName);  // Restarts the level selected
    }
}
