using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ShipHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 5;
    int currentHealth;

    public event Action<int> OnHealthChanged;
    public event Action OnDeath;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void GetHit(int damage)
    {
        currentHealth -= damage;
        OnHealthChanged?.Invoke(currentHealth);

        if (currentHealth <= 0)
            Die();
    }

    public void HealthBoost(int amount)
    {
        currentHealth = Mathf.Min(maxHealth, currentHealth + amount);
        OnHealthChanged?.Invoke(currentHealth);
    }

    void Die()
    {
        OnDeath?.Invoke();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}