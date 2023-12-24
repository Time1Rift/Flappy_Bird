using System;
using UnityEngine;

public class StartScreen : Screen
{
    [SerializeField] private SpriteRenderer _bird;

    public event Action PlayBattonClick;

    private void Start()
    {
        CanvasGroup.alpha = 1;
        CanvasGroup.interactable = true;
        CanvasGroup.blocksRaycasts = true;
    }

    public override void Close()
    {
        _bird.gameObject.SetActive(false);
        base.Close();
    }

    protected override void OnButtonClick()
    {
        PlayBattonClick?.Invoke();
    }
}