using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class PipeGenerator : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperbound;
    [SerializeField] private PipePool _pool;

    private void Start()
    {
        StartCoroutine(nameof(GeneratePipes));
    }

    private IEnumerator GeneratePipes()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Spawn();
            yield return wait;
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_lowerBound, _upperbound);
        Vector3 spawnPosition = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        var pipe = _pool.GetObject();
        pipe.gameObject.SetActive(true);
        pipe.transform.position = spawnPosition;
    }
}
