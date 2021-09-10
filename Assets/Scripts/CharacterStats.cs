using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [Header("Character Stats")]
    [SerializeField] public int _maxHealth = 3;
    [SerializeField] public int _currentHealth;
    [SerializeField] public bool isInvuln;

    [SerializeField] ParticleSystem _impactParticles;
    [SerializeField] AudioClip _impactSound;

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
            ImpactFeedback();
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
            AudioHelper.PlayClip2D(_impactSound, 1f);
        }
    }

    public virtual void Kill()
    {
        Debug.Log(gameObject.name + " died");
        StartCoroutine(KillObject());
        //play particles
        //play sounds
    }
    IEnumerator KillObject()
    {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }

}
