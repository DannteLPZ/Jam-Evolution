using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int _maxHealth;
    public int MaxHealth => _maxHealth;

    private int _currentHealth;
    public int CurrentHealth => _currentHealth;

    [Header("Events")]
    [SerializeField] private GameEvent _onTakeDamage;
    [SerializeField] private GameEvent _onDeath;

    private void Awake() => _currentHealth = _maxHealth;

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _onTakeDamage.Invoke();
        if (_currentHealth <= 0) Die();
    }

    public void Die()
    {
        _onDeath.Invoke();
        Destroy(gameObject);
    }
}
