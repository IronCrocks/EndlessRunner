using System;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;

    private void Start()
    {
        OnHealthChanged(_health);
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;

        if (_health < 0)
        {
            _health = 0;
        }

        OnHealthChanged(_health);

        if (_health > 0)
        {
            return;
        }
        
        Die();
    }

    private void Die()
    {
        OnDied();
    }

    protected virtual void OnHealthChanged(int health)
    {
        HealthChanged?.Invoke(health);
    }

    protected virtual void OnDied()
    {
        Died?.Invoke();
    }
}
