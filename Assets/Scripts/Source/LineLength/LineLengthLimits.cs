using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineLengthLimits : MonoBehaviour
{
    [SerializeField] private LinesDrawer _linesDrawer;
    [SerializeField] private LineLength _lengthMeasurer;
    [SerializeField] private float _threeStarsLimit;
    [SerializeField] private float _twoStarsLimit;
    [SerializeField] private float _oneStarLimit;

    private Coroutine _observing;

    public float ThreeStarsLimit => _threeStarsLimit;
    public float TwoStarsLimit => _twoStarsLimit;
    public float OneStarLimit => _oneStarLimit;

    public event Action ThreeStarsLimitExceeded;
    public event Action TwoStarsLimitExceeded;
    public event Action OneStarsLimitExceeded;

    private void OnEnable()
    {
        _linesDrawer.DrawingStarted += OnDrawingStarted;
        _linesDrawer.DrawingFinished += OnDrawingFinished;
    }

    private void OnDisable()
    {
        _linesDrawer.DrawingStarted -= OnDrawingStarted;
        _linesDrawer.DrawingFinished -= OnDrawingFinished;
    }

    private void OnDrawingStarted()
    {
        _observing = StartCoroutine(LimitsObserving());
    }

    private void OnDrawingFinished()
    {
        StopCoroutine(_observing);
    }

    private IEnumerator LimitsObserving()
    {
        yield return LimitObserving(_threeStarsLimit * _threeStarsLimit, ThreeStarsLimitExceeded);
        yield return LimitObserving(_twoStarsLimit * _twoStarsLimit, TwoStarsLimitExceeded);
        yield return LimitObserving(_oneStarLimit * _oneStarLimit, OneStarsLimitExceeded);
    }

    private IEnumerator LimitObserving(float limitSqr, Action action)
    {
        yield return new WaitWhile(() => limitSqr > _lengthMeasurer.GetValueSqr());
        Debug.Log(limitSqr);
        action?.Invoke();
    }
}
