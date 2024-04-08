using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _foodPrefab;
    [SerializeField] private Vector2 _spawnTimeRange;
    [SerializeField] private Vector2 _spawnPositionLimits;
    [SerializeField] private int _maxSpawns;

    private float _spawnTimer;

    private void Update()
    {
        _spawnTimer -= Time.deltaTime;
        if (_maxSpawns <= 0) return;
        if(_spawnTimer <= 0.0f)
        {
            float posX = Random.Range(-_spawnPositionLimits.x, _spawnPositionLimits.x);
            float posY = Random.Range(-_spawnPositionLimits.y, _spawnPositionLimits.y);
            Vector2 randomPosition = new(posX, posY);
            Instantiate(_foodPrefab, randomPosition, Quaternion.identity);
            _spawnTimer = Random.Range(_spawnTimeRange.x, _spawnTimeRange.y);
            _maxSpawns--;
        }
    }
}
