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

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += ProcessCollision;
    }
    
    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= ProcessCollision;
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Pipe)
        {
            GameOver?.Invoke();
        }
        else if (interactable is ScoringZone)
        {
            
        }
    }

    public void Reset()
    {
        
    }
}
