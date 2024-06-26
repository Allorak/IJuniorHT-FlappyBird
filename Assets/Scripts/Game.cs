using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private ObjectGenerator _objectGenerator;
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
        _startScreen.Close();
        StartGame();
    }

    private void OnRestartButtonClicked()
    {
        _endScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _bird.Reset();
        _objectGenerator.Reset();
    }
}
