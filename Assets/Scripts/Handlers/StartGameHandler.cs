using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class StartGameHandler : MonoBehaviour
{
    [SerializeField] private SaveHandler saveHandler;
    [SerializeField] private TextMeshProUGUI recordText;
    [SerializeField] private GameObject birdSprite;
    [SerializeField] private GameObject playButton;
    [SerializeField] private float endPositionYBirdSprite;
    [SerializeField] private Image panel;
    [SerializeField] private AudioHandler audioHandler;

    private bool _clickScreen; 

    private void Start()
    {
        recordText.text = saveHandler.GetBestScore().ToString();
    }
    
    public void ClickLoadLevel()
    {
        if (_clickScreen)
            return;
        
        audioHandler.PlayClick();
        _clickScreen = true;
        LoadNextLevel();
    }
    private void LoadNextLevel()
    {
        Invoke("PlaySwooshAudio",1.5f);
        var sequence = DOTween.Sequence();
        sequence.SetDelay(2.45f);
        sequence.Append(panel.DOFade(1, 0.7f).OnComplete(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }));
        birdSprite.transform.DOMoveX(endPositionYBirdSprite,2).SetEase(Ease.InBack);
        playButton.transform.DOScale(0.3f,0.65f).SetEase(Ease.InBack).OnComplete(() =>
        {
            playButton.SetActive(false);
        });
    }

    public void PlaySwooshAudio()
    {
        audioHandler.PlaySwoosh();
    }
}
