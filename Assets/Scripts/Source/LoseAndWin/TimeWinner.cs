using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeWinner : MonoBehaviour
{
    [SerializeField] private float _neededSurvivalDuration;
    [SerializeField] private GameState _gameState;

    private float _spentTime;

    public int RemaindTime => Mathf.FloorToInt(_neededSurvivalDuration - _spentTime);

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
        enabled = false;
    }

    private void Update()
    {
        _spentTime += Time.deltaTime;
        if (_spentTime >= _neededSurvivalDuration)
            _gameState.Win();
    }
}
