using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private PipeGenerator _pipeGenerator;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndScreen _endScreen;

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClicked;
        _endScreen.RestartButtonClicked += OnRestartButtonClicked;
        _bird.GameOver += OnGameOver;
    }
    
    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClicked;
        _endScreen.RestartButtonClicked -= OnRestartButtonClicked;
        _bird.GameOver -= OnGameOver;
    }
    
    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }
    
    private void OnGameOver()
    {
        Time.timeScale = 0;
        _endScreen.Open();
    }

    private void OnPlayButtonClicked()
    {
        Debug.Log("Play clicked");
        _startScreen.Close();
        StartGame();
    }

    private void OnRestartButtonClicked()
    {
        Debug.Log("Restart clicked");
        _endScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _bird.Reset();
    }
}
