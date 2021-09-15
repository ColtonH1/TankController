using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour, IDamageable
{
    [Header("Health Base")]
    [SerializeField] public int _maxHealth = 3;
    [SerializeField] public int _currentHealth;
    [SerializeField] public bool isInvuln;

    [SerializeField] ParticleSystem _impactParticles;
    [SerializeField] AudioClip _impactSound;

    private void Start()
    { 
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

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;
        Debug.Log(gameObject.name + "'s health: " + _currentHealth);
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            //ImpactFeedback();
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
        ShootProjectiles shootProjectiles = gameObject.GetComponent<ShootProjectiles>();
        if (shootProjectiles != null)
            shootProjectiles.enabled = false;
        Interactable interactable = gameObject.GetComponent<Interactable>();
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
