using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineLengthLimitView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private LineLengthLimits _limits;
    [SerializeField] private LineLength _lineLength;

    private void Update()
    {
        _slider.value = 1 - (_lineLength.GetValue() / _limits.OneStarLimit);
    }
}
