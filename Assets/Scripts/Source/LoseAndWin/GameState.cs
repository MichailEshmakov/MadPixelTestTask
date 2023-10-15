using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: separate interfaces
public class GameState : MonoBehaviour
{
    public event Action Over;
    public event Action Won;

    public void Loose()
    {
        Over?.Invoke();
    }

    public void Win()
    {
        Won?.Invoke();
    }
}
