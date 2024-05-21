using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    [SerializeField] private SaveHandler saveHandler;
    [SerializeField] private BirdBehavior bird;
    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI currentScoreStartGameText;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    private int _bestScore;
    private int _currentScore;

    private void OnEnable()
    {
        bird.OnTriggerPoint += AddPoint;
    }

    private void OnDisable()
    {
        bird.OnTriggerPoint -= AddPoint;
    }

    private void Start()
    {
        _bestScore = saveHandler.GetBestScore();
        bestScoreText.text = _bestScore.ToString();
        currentScoreText.text = _currentScore.ToString();
    }

    private void AddPoint()
    {
        _currentScore++;
        currentScoreStartGameText.text = _currentScore.ToString();
    }
    public void CheckRecord()
    {
        bestScoreText.text = _bestScore.ToString();
        currentScoreText.text = _currentScore.ToString();
        
        if (_currentScore < _bestScore)
            return;
        
        SetNewRecord(_currentScore);
    }

    private void SetNewRecord(int newRecord)
    {
        _bestScore = newRecord;
        bestScoreText.text = _bestScore.ToString();
        saveHandler.SetBestScore(_bestScore);
    }

    public int GetCurrentScore()
    {
        return _currentScore;
    }
    public int GetBestScore()
    {
        return _bestScore;
    }
}
