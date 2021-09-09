using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] public int _maxHealth = 3;
    [SerializeField] public int _currentHealth;
    [SerializeField] public bool isInvuln;

    private void Start()
    {
        Debug.Log(gameObject.name + " Max health is " + _maxHealth);
        _currentHealth = _maxHealth;
    }
    private void Update()
    {
        //isInvuln = Invincibility.isActive;
    }

    public void IncreaseHealth(int amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        Debug.Log(gameObject.name + "'s health: " + _currentHealth);
    }

    public void DecreaseHealth(int amount)
    {
        _currentHealth -= amount;
        Debug.Log(gameObject.name + "'s health: " + _currentHealth);
        if (_currentHealth <= 0)
        {
            Kill();
        }
    }

    public virtual void Kill()
    {
        Debug.Log(gameObject.name + " died");
        gameObject.SetActive(false);
        //play particles
        //play sounds
    }
}
