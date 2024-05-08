using System;
using UnityEngine;

public class BirdTracker : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private float _xOffset;

    private void Update()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x = _bird.transform.position.x + _xOffset;
        transform.position = currentPosition;
    }
}
