using System;
using UnityEngine;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    private BirdMover _mover;
    private int _score = 0;

    public event Action GameOver;
    public event Action<int> ScoreChanged;

    private void Start()
    {
        _mover = GetComponent<BirdMover>();
        gameObject.SetActive(false);
    }

    public void ResetPlayer()
    {
        gameObject.SetActive(true);
        _score = 0;
        ScoreChanged?.Invoke(_score);
        _mover.ResetBird();
    }

    public void AddScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void Die()
    {
        GameOver?.Invoke();
    }
}