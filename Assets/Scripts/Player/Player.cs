using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankController))]
public class Player : MonoBehaviour
{
    [SerializeField] int _maxHealth = 3;
    int _currentHealth;
    [SerializeField] public bool isInvuln;

    TankController _tankController;
    private void Awake()
    {
        _tankController = GetComponent<TankController>();        
    }
    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        isInvuln = Invincibility.isActive;
    }

    public void IncreaseHealth(int amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        Debug.Log("Player's health: " + _currentHealth);
    }

    public void DecreaseHealth(int amount)
    {
        _currentHealth -= amount;
        Debug.Log("Player's health: " + _currentHealth);
        if(_currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        gameObject.SetActive(false);
        //play particles
        //play sounds
    }
}
