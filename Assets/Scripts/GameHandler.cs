using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private BirdBehavior birdBehavior;
    [SerializeField] private GameScore gameScore;
    [SerializeField] private SpriteRenderer tutorialGameSpriteRenderer;
    [SerializeField] private GameObject finishPanel;
    [SerializeField] private Image startPanel;
    [SerializeField] private AudioHandler audioHandler;

    private float _valueTopYPositionFinishPanel = -28f;
    private float _valueBottomYPositionFinishPanel = -1405f;
    private bool _startGame;

    public Action<bool> OnStartGame;

    private void OnEnable()
    {
        birdBehavior.OnCollisionGroundAndPipe += GameOver;
    }

    private void OnDisable()
    {
        birdBehavior.OnCollisionGroundAndPipe -= GameOver;
    }

    private void Start()
    {
        startPanel.DOFade(0, 1f);
        tutorialGameSpriteRenderer.DOFade(1, 0.35f);
    }

    private void Update()
    {
        if (_startGame)
            return;
        
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            StartGame();
        }
    }
    
    public void StartGame()
    {
        _startGame = true;
        birdBehavior.SetGravity(true);
        OnStartGame?.Invoke(_startGame);
        
        tutorialGameSpriteRenderer.DOFade(0, 0.4f).OnComplete(() =>
        {
            tutorialGameSpriteRenderer.gameObject.SetActive(false);
        });
        
    }
    public void GameOver()
    {
        audioHandler.PlayDead();
        audioHandler.PlayHit();
        gameScore.CheckRecord();
        var sequence = DOTween.Sequence().SetUpdate(UpdateType.Normal,true);
        sequence.SetDelay(0.15f);
        sequence.Append(finishPanel.transform.DOLocalMoveY(_valueTopYPositionFinishPanel, 1f).SetEase(Ease.OutBack));
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        audioHandler.PlayClick();

        var sequence = DOTween.Sequence().SetUpdate(UpdateType.Normal, true);
        sequence.SetDelay(0.75f);
        sequence.Append(startPanel.DOFade(1, 0.5f).OnComplete(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }));
        
        finishPanel.transform.DOLocalMoveY(_valueBottomYPositionFinishPanel, 0.85f).SetEase(Ease.InBack).
            SetUpdate(UpdateType.Normal,true).OnComplete(() =>
            {
                audioHandler.PlaySwoosh();
            });
    }

    
}
