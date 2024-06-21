using System;
using UnityEngine;
using UnityTools;
using UnityTools.Extentions;
using Random = UnityEngine.Random;

public class ItemsSpawnerComponent : MonoBehaviour
{
    [SerializeField] private GameConfig _config;

    [SerializeField] private Transform _spawnOrigin;
    [SerializeField] private Vector2 _spawnArea;

    private Timer _timer;

    public bool shouldSpawn { get; set; }

    private void Awake()
    {
        _timer = new Timer(_config.spawnDelay);
    }

    private void Update()
    {
        if (!shouldSpawn) return;
        _timer.UpdateTimer();
        if (_timer.isReady)
        {
            SpawnObject();
            _timer.Reset();
        }
    }

    private void SpawnObject()
    {
        var objectToSpawn = _config.objectsToSpawn.GetRandom();
        var size = Random.Range(_config.objectSizeRange.x, _config.objectSizeRange.y);
        var spawnPosition = _spawnOrigin.position + new Vector3(Random.Range(_spawnArea.x, -_spawnArea.x), 0, Random.Range(_spawnArea.y, -_spawnArea.y));
        var instance = Instantiate(objectToSpawn);
        instance.transform.position = spawnPosition;
        instance.transform.localScale = Vector3.one * size;
        instance.transform.rotation = Random.rotation;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(_spawnOrigin.position, new Vector3(_spawnArea.x*2, 1, _spawnArea.y*2));
    }
}
