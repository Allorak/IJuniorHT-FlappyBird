using System;
using UnityEngine;

[RequireComponent(typeof(BirdMover))]
[RequireComponent(typeof(BirdCollisionHandler))]
public class Bird : MonoBehaviour
{
    private BirdMover _mover;
    private BirdCollisionHandler _collisionHandler;

    public event Action GameOver;

    private void Awake()
    {
        _mover = GetComponent<BirdMover>();
        _collisionHandler = GetComponent<BirdCollisionHandler>();
    }

    public void Reset()
    {
        
    }
}
