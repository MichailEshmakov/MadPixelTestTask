using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    [SerializeField] private GameState _gameState;

    private void OnValidate()
    {
        if (_gameState == null)
            _gameState = FindObjectOfType<GameState>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Dangerous dangerous))
        {
            _gameState.Loose();
        }
    }
}
