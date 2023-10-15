using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BeeBouncer : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _angle;
    [SerializeField] private float _duration;

    private float _spentTime;
    private Coroutine _moving;

    public event Action Finished;

    public void Bounce(Vector2 direction)
    {
        if (_moving == null)
        {
            Vector2 bounceDirection = RandomizeDirection(direction);
            _moving = StartCoroutine(Moving(bounceDirection));
        }
    }

    private Vector2 RandomizeDirection(Vector2 direction)
    {
        Quaternion rotation = Quaternion.Euler(0, 0, Random.Range(-_angle, _angle));
        return rotation * direction.normalized;
    }

    private IEnumerator Moving(Vector2 direction)
    {
        _spentTime = 0;

        while (_spentTime < _duration)
        {
            _spentTime += Time.fixedDeltaTime;
            _rigidbody.velocity = direction *  _speed;
            yield return new WaitForFixedUpdate();
        }

        _rigidbody.velocity = Vector2.zero;
        Finished?.Invoke();
        _moving = null;
    }
}
