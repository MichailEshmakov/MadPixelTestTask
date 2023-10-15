using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosingMenuShower : MonoBehaviour
{
    [SerializeField] private GameObject _losingMenu;
    [SerializeField] private GameState _gameState;

    private void OnEnable()
    {
        _gameState.Over += OnGameOver;
    }

    private void OnDisable()
    {
        _gameState.Over -= OnGameOver;
    }

    private void OnGameOver()
    {
        _losingMenu.SetActive(true);
    }
}
