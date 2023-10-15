using System.Collections;
using UnityEngine;

public class LineLength : MonoBehaviour
{
    [SerializeField] private LinesDrawer _linesDrawer;

    private Vector2 _length;
    private bool _isDrawingFinished;
    private Vector2 _previousMousePosition;

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

    public float GetValueSqr()
    {
        return _length.sqrMagnitude;    
    }

    public float GetValue()
    {
        return _length.magnitude;
    }

    private void OnDrawingStarted()
    {
        _isDrawingFinished = false;
        StartCoroutine(Counting());
    }

    private void OnDrawingFinished()
    {
        _isDrawingFinished = true;
    }

    private IEnumerator Counting()
    {
        _previousMousePosition = ComputeMousePosition();
        while (_isDrawingFinished == false)
        {
            Vector2 newMousePosition = ComputeMousePosition();
            Vector2 changing = _previousMousePosition - newMousePosition;
            _length += new Vector2(Mathf.Abs(changing.x), Mathf.Abs(changing.y));
            _previousMousePosition = newMousePosition;
            yield return null;
        }
    }

    private Vector2 ComputeMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
