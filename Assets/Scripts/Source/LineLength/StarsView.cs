using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsView : MonoBehaviour
{
    [SerializeField] private LineLengthLimits _limits;
    [SerializeField] private List<GameObject> _thirdStar;
    [SerializeField] private List<GameObject> _secondStar;

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


    private void OnTwoStarsLimitExceeded()
    {
        _secondStar.ForEach(star => star.SetActive(false));
    }

    private void OnThreeStarsLimitExceeded()
    {
        _thirdStar.ForEach(star => star.SetActive(false));
    }
}
