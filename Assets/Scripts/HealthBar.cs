using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider HSlider;
    public Gradient HealthBarGradient;
    public Image newBar;

    public void SetMaxHealth(int health)
    {
        HSlider.maxValue = health;
        HSlider.value = health;
        HealthBarGradient.Evaluate(1f);
        newBar.color = HealthBarGradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        HSlider.value = health;
        newBar.color = HealthBarGradient.Evaluate(HSlider.normalizedValue);
    }
}
