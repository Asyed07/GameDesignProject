using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject difficultyPage;
    public GameObject menuPage;

    public void OnStartButtonClicked()
    {
        if (GameProgressManager.IsFirstTime())
        {
            // Show difficulty selection
            menuPage.SetActive(false);
            difficultyPage.SetActive(true);
        }
        else
        {
            // Skip difficulty page and go to saved level
            int level = GameProgressManager.LoadLevel();
            SceneManager.LoadScene("Level" + level);
        }
    }
}
