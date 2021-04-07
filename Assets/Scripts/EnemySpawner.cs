using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _template;
    private Transform[] _spawnPoints;
    private float _delayTime;

    private void Start()
    {
        _spawnPoints = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _spawnPoints[i] = transform.GetChild(i);
        }
        _delayTime = 2f;
        Spawn();
    }

    private void Update()
    {
        _delayTime -= Time.deltaTime;

        if (_delayTime <= 0)
        {
            Spawn();
            _delayTime = 2f;
        }
    }

    private void Spawn()
    {
        Instantiate(_template, _spawnPoints[Random.Range(0, 2)].position, Quaternion.identity);
    }
}
