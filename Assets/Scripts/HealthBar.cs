using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider HealthFillSlider;

    public void MaxHealth(int health)
    {
        HealthFillSlider.maxValue = health;
        HealthFillSlider.value = health;
    }

    public void SetHealth(int health)
    {
        HealthFillSlider.value = health;
    }
}
