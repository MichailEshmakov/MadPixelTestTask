using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPauser : MonoBehaviour
{
    [SerializeField] private Pauser _pauser;
    [SerializeField] private LinesDrawer _linesDrawer;

    private void OnEnable()
    {
        _linesDrawer.DrawingFinished += OnDrawingFinished;
    }

    private void OnDisable()
    {
        _linesDrawer.DrawingFinished -= OnDrawingFinished;
    }

    private void Start()
    {
        _pauser.Pause();
    }

    private void OnDrawingFinished()
    {
        _pauser.Unpause();
        _linesDrawer.enabled = false;
        // TODO: separate
    }
}
