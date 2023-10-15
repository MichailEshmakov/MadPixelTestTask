using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningMenuShower : MonoBehaviour
{
    [SerializeField] private GameObject _winningMenu;
    [SerializeField] private GameState _gameState;

    private void OnEnable()
    {
        _gameState.Won += OnPlayerWon;
    }

    private void OnDisable()
    {
        _gameState.Won -= OnPlayerWon;
    }

    private void OnPlayerWon()
    {
        _winningMenu.SetActive(true);
    }
}
