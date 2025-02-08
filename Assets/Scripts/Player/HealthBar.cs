using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider HealthSlider;
    public Gradient HealthBarGradient;
    public Image newBar;

    public void SetMaxHealth(float health)
    {
        HealthSlider.maxValue = health;
        HealthSlider.value = health;
        HealthBarGradient.Evaluate(1f);
        newBar.color = HealthBarGradient.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
        HealthSlider.value = health;
        newBar.color = HealthBarGradient.Evaluate(HealthSlider.normalizedValue);
    }
}