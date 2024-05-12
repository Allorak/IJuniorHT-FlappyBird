using UnityEngine;

public class Enemy : PoolingObject, IInteractable
{
    [SerializeField] private float _speed;

    private void Update()
    {
        var distance = _speed * Time.deltaTime;
        transform.Translate(Vector3.left * distance);
    }
}
