using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = -1;
        GameTimer timer = FindFirstObjectByType<GameTimer>();
        if (timer != null)
        {
            timer.StartTimer();
        }
    }
}
