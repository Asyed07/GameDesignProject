using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GoToScene(string sceneName) // Loads the scene selected in unity
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitApp() // Player can close the application
    {
        Application.Quit();
        Debug.Log("Application has quit.");
    }
}