using System.Collections;
using UnityEngine;

public class PipeGenerator : ObjectPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _maxSpawnPositionY;
    [SerializeField] private float _minSpawnPositionY;

    private Coroutine _spawnPipe;
    private Vector3 _previousPositionSpawned;

    private void Start()
    {
        Initializ(_template);
    }

    public void StartSpawnPipe()
    {
        if (_spawnPipe != null)
            StopCoroutine(_spawnPipe);

        _spawnPipe = StartCoroutine(SpawnPipe());
    }

    private void CreatObgect(GameObject pipe)
    {
        float spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
        Vector3 spawnPosition = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
        pipe.SetActive(true);
        pipe.transform.position = spawnPosition;
    }

    private IEnumerator SpawnPipe()
    {
        WaitForSeconds cooldown = new WaitForSeconds(_secondsBetweenSpawn);

        while (enabled)
        {
            if (transform.position != _previousPositionSpawned && TryGetObject(out GameObject pipe))
            {
                CreatObgect(pipe);
                DisableObjectAbroadScreen();
                _previousPositionSpawned = transform.position;
            }

            yield return cooldown;
        }
    }
}