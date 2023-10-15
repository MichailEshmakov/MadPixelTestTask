using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlimitAutoStarter : MonoBehaviour
{
    [SerializeField] private LineLengthLimits _lineLengthLimits;
    [SerializeField] private LinesDrawer _drawer;

    private void OnEnable()
    {
        _lineLengthLimits.OneStarsLimitExceeded += OnOneStarsLimitExceeded;
    }

    private void OnDisable()
    {
        _lineLengthLimits.OneStarsLimitExceeded -= OnOneStarsLimitExceeded;
    }

    private void OnOneStarsLimitExceeded()
    {
        _drawer.EndDraw();
    }
}
