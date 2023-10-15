using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLostPauser : MonoBehaviour
{
    [SerializeField] private GameState _gameState;
    [SerializeField] private Pauser _pauser;

    private void OnEnable()
    {
        _gameState.Over += _pauser.Pause;
    }

    private void OnDisable()
    {
        _gameState.Over -= _pauser.Pause;
    }
}
