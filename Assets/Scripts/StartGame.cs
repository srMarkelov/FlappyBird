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

public class StartGame : MonoBehaviour
{
    [SerializeField] private SaveHandler saveHandler;
    [SerializeField] private TextMeshProUGUI recordText;
    [SerializeField] private GameObject birdSprite;
    [SerializeField] private GameObject playButton;
    [SerializeField] private float endPositionYBirdSprite;
    [SerializeField] private float endPositionYPlayButton;
    [SerializeField] private Image panel;

    private bool _clickScreen; 

    private void Start()
    {
        recordText.text = saveHandler.GetBestScore().ToString();
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (_clickScreen)
                return;

            _clickScreen = true;
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        var sequence = DOTween.Sequence();
        sequence.SetDelay(2.45f);
        sequence.Append(panel.DOFade(1, 0.7f).OnComplete(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }));
        
        
        
        birdSprite.transform.DOMoveX(endPositionYBirdSprite,3).SetEase(Ease.InBack);
        playButton.transform.DOScale(0.3f,1).SetEase(Ease.InBack).OnComplete(() =>
        {
            playButton.SetActive(false);
        });
    }
}
