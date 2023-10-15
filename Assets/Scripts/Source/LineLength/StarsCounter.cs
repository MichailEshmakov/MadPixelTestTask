using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsCounter : MonoBehaviour
{
    [SerializeField] private LineLengthLimits _limits;

    private int _stars = 3;

    public int Stars => _stars;

    private void OnEnable()
    {
        _limits.ThreeStarsLimitExceeded += OnThreeStarsLimitExceeded;
        _limits.TwoStarsLimitExceeded += OnTwoStarsLimitExceeded;
    }

    private void OnDisable()
    {
        _limits.ThreeStarsLimitExceeded -= OnThreeStarsLimitExceeded;
        _limits.TwoStarsLimitExceeded -= OnTwoStarsLimitExceeded;
    }

    private void OnThreeStarsLimitExceeded()
    {
        _stars--;
    }

    private void OnTwoStarsLimitExceeded()
    {
        _stars--;
    }
}
