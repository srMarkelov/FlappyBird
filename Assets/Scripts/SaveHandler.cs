using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveHandler : MonoBehaviour
{
    private int _bestScore;

    private void Awake()
    {
        _bestScore = PlayerPrefs.GetInt("Record");
    }
    
    public int GetBestScore()
    {
        return _bestScore;
    }

    public void SetBestScore(int bestScore)
    {
        _bestScore = bestScore;
        PlayerPrefs.SetInt("Record", _bestScore);
    }

}
