using System.Collections;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperbound;
    [SerializeField] private ObjectPool _pool;

    private void Start()
    {
        StartCoroutine(nameof(GenerateObjects));
    }
    
    public void Reset()
    {
        _pool.Reset();
    }

    private IEnumerator GenerateObjects()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            yield return wait;
            Spawn();
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_lowerBound, _upperbound);
        Vector3 spawnPosition = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        var obj = _pool.GetObject();
        obj.gameObject.SetActive(true);
        obj.transform.position = spawnPosition;
    }
}
