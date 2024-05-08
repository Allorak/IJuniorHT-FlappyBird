using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _maxRotationZ;
    
    private Rigidbody2D _rigidbody2D;
    private Vector3 _startPosition;
    private Quaternion _minRotation;
    private Quaternion _maxRotation;
    private Vector2 _defaultVelocityVector;

    private void OnValidate()
    {
        if (_maxRotationZ < _minRotationZ)
            _maxRotationZ = _minRotationZ;
    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _startPosition = transform.position;
        _defaultVelocityVector = new Vector2(_speed, _tapForce);
        
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
            Jump();

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        _rigidbody2D.velocity = _defaultVelocityVector;
        transform.rotation = _maxRotation;
    }
}
