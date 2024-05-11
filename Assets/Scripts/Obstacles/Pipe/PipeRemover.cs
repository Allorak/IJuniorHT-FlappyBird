using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PipeRemover : MonoBehaviour
{
    [SerializeField] private PipePool _pool;

    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Pipe pipe))
        {
            _pool.PutObject(pipe);
        }
    }
}
