using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _templates;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _timeBetweenSpawns;
    private float _elapsedTime = 0;

    private void Start()
    {
        Initialize(_templates);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _timeBetweenSpawns)
        {
            if (TryGetObject(out GameObject enemy))
            {
                _elapsedTime = 0;
                var spawnPointIndex = Random.Range(0, _spawnPoints.Length);
                SetActive(enemy, _spawnPoints[spawnPointIndex].position);
            }
        }
    }

    private void SetActive(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.transform.position = spawnPoint;
        enemy.SetActive(true);
    }
}
