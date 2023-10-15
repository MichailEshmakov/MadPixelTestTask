using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeBounceSwitcher : MonoBehaviour
{
    [SerializeField] private AIPath _aiPath;
    [SerializeField] private BeeBouncer _bouncer;
    [SerializeField] private float _pushingTime;

    private Coroutine _pushing;
    private Collision2D _lineCollision;

    private void OnEnable()
    {
        _bouncer.Finished += OnBouncerFinished;
    }

    private void OnDisable()
    {
        _bouncer.Finished -= OnBouncerFinished;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Line line))
        {
            _lineCollision = collision;
            StartPushingIfNeed();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision == _lineCollision)
            StartPushingIfNeed();
    }

    private void OnBouncerFinished()
    {
        _aiPath.enabled = true;
    }

    private void StartPushingIfNeed()
    {
        if (_aiPath.enabled)
        {
            if (_pushing == null)
            {
                _pushing = StartCoroutine(Pushing(_aiPath.desiredVelocity));
            }
        }
    }

    private IEnumerator Pushing(Vector2 direction)
    {
        yield return new WaitForSeconds(_pushingTime);
        _pushing = null;
        Bounce(-direction);
    }

    private void Bounce(Vector2 direction)
    {
        _aiPath.enabled = false;
        _bouncer.Bounce(direction);
    }
}
