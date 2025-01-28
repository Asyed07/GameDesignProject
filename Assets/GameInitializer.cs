using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    void Start()
    {
        GameTimer timer = FindObjectOfType<GameTimer>();
        if (timer != null)
        {
            timer.StartTimer();
        }
    }
}
