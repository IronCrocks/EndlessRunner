using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Heart _heartPrefab;

    private List<Heart> _hearts = new List<Heart>();

    private void OnEnable()
    {
        _player.HealthChanged += player_HealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= player_HealthChanged;
    }

    private void player_HealthChanged(int health)
    {
        if (_hearts.Count < health)
        {
            int heartsCount = health - _hearts.Count;

            for (int i = 0; i < heartsCount; i++)
            {
                CreateHeart();
            }
        }
        else if (_hearts.Count > health)
        {
            int heartsCount = _hearts.Count - health;

            for (int i = 0; i < heartsCount; i++)
            {
                RemoveHeart();
            }
        }
    }

    private void CreateHeart()
    {
        var heart = Instantiate(_heartPrefab, transform);
        _hearts.Add(heart);
        heart.ToFill();
    }
    private void RemoveHeart()
    {
        var heart = _hearts.Last();
        _hearts.RemoveAt(_hearts.Count - 1);
        heart.ToEmpty();
    }
}
