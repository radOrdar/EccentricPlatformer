using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private AudioSource AddHealthSound;
    [SerializeField] private HealthUI HealthUI;
    [SerializeField] private UnityEvent OnTakeDamage;

    public int Health = 5;
    public int MaxHealth = 8;
    public float durationInvulnerabilityAfterTakeDamage = 1f;

    private bool _invulnerable;

    private void Start()
    {
        HealthUI.Init(MaxHealth, Health);
    }

    public void TakeDamage(int damageValue)
    {
        if (_invulnerable == false)
        {
            Health = Mathf.Clamp(Health - damageValue, 0, MaxHealth);
            if (Health <= 0)
            {
                Health = 0;
                Die();
            }

            _invulnerable = true;
            Invoke(nameof(StopInvulnerable), durationInvulnerabilityAfterTakeDamage);

            HealthUI.SetHealth(Health);
            OnTakeDamage?.Invoke();
        }
    }

    public void AddHealth(int healthBoost)
    {
        Health = Mathf.Clamp(Health + healthBoost, 0, MaxHealth);
        HealthUI.SetHealth(Health);
        AddHealthSound.Play();
    }

    private void StopInvulnerable()
    {
        _invulnerable = false;
    }

    private void Die()
    {
        Debug.Log("You lose");
    }
}