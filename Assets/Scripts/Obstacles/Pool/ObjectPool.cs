using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private PoolingObject _prefab;

    private Queue<PoolingObject> _pool;

    public IEnumerable<PoolingObject> PooledObjects => _pool;

    private void Awake()
    {
        _pool = new Queue<PoolingObject>();
    }

    public PoolingObject GetObject()
    {
        if (_pool.Count == 0)
            return Instantiate(_prefab, _container, true);

        return _pool.Dequeue();
    }

    public void PutObject(PoolingObject poolingObject)
    {
        _pool.Enqueue(poolingObject);
        poolingObject.gameObject.SetActive(false);
    }

    public void Reset()
    {
        for (int i = _container.childCount - 1; i >= 0; i--)
            Destroy(_container.GetChild(i).gameObject);

        _pool.Clear();
    }
}
