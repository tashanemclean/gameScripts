using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behemut : MonoBehaviour, IEnemy
{
    public float currentHealth, strength, dexterity;
    public event Action<float> OnHealthPctChanged = delegate { };
    public float maxHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void PerformAttack()
    {
        throw new NotImplementedException();
    }

    public void TakeDamange(int amount)
    {
        currentHealth -= amount;
        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged(currentHealthPct);
        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}