using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    [SerializeField] GameObject character;
    private HealthBase healthBase;

    private void Awake()
    {
        healthBase = character.GetComponent<HealthBase>();
    }

    private void OnEnable()
    {
        if(healthBase != null)
        {
            healthBase.characterMaxHealth += SetMaxHealth;
            healthBase.characterCurrentHealth += SetHealth;
        }

    }

    private void OnDisable()
    {
        if(healthBase != null)
        {
            healthBase.characterMaxHealth -= SetMaxHealth;
            healthBase.characterCurrentHealth -= SetHealth;
        }

    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(2f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
