using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    void Start()
    {
        GameTimer timer = FindFirstObjectByType<GameTimer>();
        if (timer != null)
        {
            timer.StartTimer();
        }
    }
}
