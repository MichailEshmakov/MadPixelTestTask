using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnWinPauser : MonoBehaviour
{
    [SerializeField] private GameState _gameState;
    [SerializeField] private Pauser _pauser;

    private void OnEnable()
    {
        _gameState.Won += _pauser.Pause;
    }

    private void OnDisable()
    {
        _gameState.Won -= _pauser.Pause;
    }
}
