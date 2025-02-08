using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Slider EnemySlider;
    public Gradient EnemyHealthGradient;
    public Image newBar;

    public void SetMaxHealth(float health)
    {
        EnemySlider.maxValue = health;
        EnemySlider.value = health;
        EnemyHealthGradient.Evaluate(1f);
        newBar.color = EnemyHealthGradient.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
        EnemySlider.value = health;
        newBar.color = EnemyHealthGradient.Evaluate(EnemySlider.normalizedValue);
    }
}