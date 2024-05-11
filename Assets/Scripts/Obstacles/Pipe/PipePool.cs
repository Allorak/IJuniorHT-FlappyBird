using System;
using System.Collections.Generic;
using UnityEngine;

public class PipePool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Pipe _prefab;

    private Queue<Pipe> _pool;

    public IEnumerable<Pipe> PooledObjects => _pool;

    private void Awake()
    {
        _pool = new Queue<Pipe>();
    }

    public Pipe GetObject()
    {
        if (_pool.Count == 0)
        {
            var pipe = Instantiate(_prefab, _container, true);
            return pipe;
        }

        return _pool.Dequeue();
    }

    public void PutObject(Pipe pipe)
    {
        _pool.Enqueue(pipe);
        pipe.gameObject.SetActive(false);
    }

    public void Reset()
    {
        _pool.Clear();
    }
}
