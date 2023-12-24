using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private PipeGenerator _pipeGenerator;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;

    private void Start()
    {
        _startScreen.Open();
    }

    private void OnEnable()
    {
        _startScreen.PlayBattonClick += OnPlayBattonClick;
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
        _bird.GameOver += OnGameOver; 
    }

    private void OnDisable()
    {
        _startScreen.PlayBattonClick -= OnPlayBattonClick;
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
        _bird.GameOver -= OnGameOver;
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _gameOverScreen.Open();
    }

    private void OnPlayBattonClick()
    {
        _startScreen.Close();
        StartGame();
        _pipeGenerator.StartSpawnPipe();
    }

    private void OnRestartButtonClick()
    {
        _gameOverScreen.Close();
        _pipeGenerator.ResetPool();
        StartGame();
    }

    private void StartGame()
    {
        _bird.ResetPlayer();
        Time.timeScale = 1;
    }
}