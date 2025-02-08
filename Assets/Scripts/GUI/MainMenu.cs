using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        if (PlayerPrefs.GetInt("FirstTime", 0) == 1) // Check if difficulty has been selected
        {
            int savedLevel = PlayerPrefs.GetInt("CurrentLevel", 1); // Load saved level
            SceneManager.LoadScene("Level" + savedLevel); // Load the saved level
        }
        else
        {
            SceneManager.LoadScene("DifficultySelection"); // Load difficulty selection screen
        }
    }

    public void GoToScene(string sceneName) // Loads the scene selected in Unity
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitApp() // Player can close the application
    {
        Application.Quit();
        Debug.Log("Application has quit.");
    }
}
