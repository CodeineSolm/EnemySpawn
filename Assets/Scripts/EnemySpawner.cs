using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _template;
    [SerializeField] private float _delayTime;
    private Transform[] _spawnPoints;
    private float _delaySpawnTime;

    private void Start()
    {
        _spawnPoints = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _spawnPoints[i] = transform.GetChild(i);
        }
        _delaySpawnTime = _delayTime;
        Spawn();
    }

    private void Update()
    {
        _delaySpawnTime -= Time.deltaTime;

        if (_delaySpawnTime <= 0)
        {
            Spawn();
            _delaySpawnTime = _delayTime;
        }
    }

    private void Spawn()
    {
        Instantiate(_template, _spawnPoints[Random.Range(0, 2)].position, Quaternion.identity);
    }
}
