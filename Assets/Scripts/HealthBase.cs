/*
 * This script is the base for the health scripts. It uses the IDamageable interface
 * This script can increase and decrease health
 * This script can kill the character 
 * This script determines the impact result
 * This script returns the gameobject the health script is attached to 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthBase : MonoBehaviour, IDamageable
{
    public event Action<int> CharacterMaxHealth;
    public event Action<int> CharacterCurrentHealth;

    [Header("Health Base")]
    [SerializeField] public int _maxHealth = 3;
    [SerializeField] public int _currentHealth;
    [SerializeField] public bool isInvuln;

    [SerializeField] ParticleSystem _impactParticles;
    [SerializeField] AudioClip _impactSound;

    public HealthBar healthBar;

    private void Start()
    {
        _currentHealth = _maxHealth;
        CharacterMaxHealth?.Invoke(_maxHealth);
    }

    public void IncreaseHealth(int amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        Debug.Log(gameObject.name + "'s health: " + _currentHealth);
    }

    public virtual void TakeDamage(int amount)
    {
        _currentHealth -= amount;
        CharacterCurrentHealth?.Invoke(_currentHealth);
        Debug.Log(gameObject.name + "'s health: " + _currentHealth);
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            Kill();
        }
    }

    private void ImpactFeedback()
    {
        //particles
        if (_impactParticles != null)
        {
            _impactParticles = Instantiate(_impactParticles, transform.position, Quaternion.identity);
        }

        //audio. TODO - consider Object Pooling for performance 
        if (_impactSound != null)
        {
            Debug.Log("Playing " + _impactSound);
            AudioHelper.PlayClip2D(_impactSound, 1f);
        }
    }

    public virtual void Kill()
    {
        Debug.Log(gameObject.name + " died");

        ImpactFeedback();

        MeshRenderer meshRenderer = gameObject.GetComponentInChildren<MeshRenderer>();
        if (meshRenderer != null)
            meshRenderer.enabled = false;
        Collider collider = gameObject.GetComponent<Collider>();
        if (collider != null)
            collider.enabled = false;
        ShootProjectilesBase shootProjectiles = gameObject.GetComponent<ShootProjectilesBase>();
        if (shootProjectiles != null)
            shootProjectiles.enabled = false;
        InteractableBase interactable = gameObject.GetComponent<InteractableBase>();
        if (interactable != null)
            interactable.enabled = false;
        StartCoroutine(KillObject());
    }
    IEnumerator KillObject()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

}
