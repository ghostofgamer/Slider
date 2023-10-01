using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private readonly float _minHealth = 0f;

    public float CurrentHealth { get; private set; } = 50f;
    public float MaxHealth { get; private set; } = 100f;

    public UnityAction<float> HealthChanged;

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        CurrentHealth = Mathf.Clamp(CurrentHealth, _minHealth, MaxHealth);
        HealthChanged?.Invoke(CurrentHealth);
    }

    public void AddHealth(float heal)
    {
        CurrentHealth += heal;
        CurrentHealth = Mathf.Clamp(CurrentHealth, _minHealth, MaxHealth);
        HealthChanged?.Invoke(CurrentHealth);
    }
}
