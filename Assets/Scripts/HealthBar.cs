/*
 * This script observes the health base script
 * This script sets the health bar gradient
 */
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider; //health slider
    public Gradient gradient; //set color to change
    public Image fill; //image with color for health
    [SerializeField] GameObject character; //character the health bar is attached to
    private HealthBase healthBase; //script this one is listening to


    private void Awake()
    {
        healthBase = character.GetComponent<HealthBase>();
        fill = healthSlider.GetComponentInChildren<Image>();
    }

    private void OnEnable()
    {
        healthBase.CharacterMaxHealth += SetMaxHealth;
        healthBase.CharacterCurrentHealth += SetHealth;
    }

    private void OnDisable()
    {
        healthBase.CharacterMaxHealth -= SetMaxHealth;
        healthBase.CharacterCurrentHealth -= SetHealth;
    }

    public void SetMaxHealth(int health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;

        fill.color = gradient.Evaluate(2f);
    }

    public void SetHealth(int health)
    {
        healthSlider.value = health;

        fill.color = gradient.Evaluate(healthSlider.normalizedValue);
    }
}
