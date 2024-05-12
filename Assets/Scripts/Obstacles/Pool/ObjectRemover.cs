using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ObjectRemover : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;

    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PoolingObject poolingObject))
        {
            _pool.PutObject(poolingObject);
        }
    }
}
