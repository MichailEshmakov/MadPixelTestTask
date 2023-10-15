using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hive : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private AIDestinationSetter _beePrefab;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private Transform _parent;
    [SerializeField] private float _delay;

    private void OnValidate()
    {
        if (_target == null)
            _target = FindObjectOfType<Damagable>()?.transform;
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(_delay);

        foreach (Transform spawnPoint in _spawnPoints)
        {
            AIDestinationSetter bee = Instantiate(_beePrefab, spawnPoint.position, Quaternion.identity, _parent);
            bee.target = _target;
        }
    }
}
