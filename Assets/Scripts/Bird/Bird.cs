using System;
using UnityEngine;

[RequireComponent(typeof(BirdMover))]
[RequireComponent(typeof(BirdCollisionHandler))]
[RequireComponent(typeof(ScoreCounter))]
public class Bird : MonoBehaviour
{
    private BirdMover _mover;
    private BirdCollisionHandler _collisionHandler;
    private ScoreCounter _scoreCounter;

    public event Action GameOver;

    private void Awake()
    {
        _mover = GetComponent<BirdMover>();
        _collisionHandler = GetComponent<BirdCollisionHandler>();
        _scoreCounter = GetComponent<ScoreCounter>();
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
        switch (interactable)
        {
            case Pipe or Ground:
                GameOver?.Invoke();
                break;
            case ScoringZone:
                _scoreCounter.Increase();
                break;
        }
    }

    public void Reset()
    {
        _scoreCounter.Reset();
        _mover.Reset();
    }
}
