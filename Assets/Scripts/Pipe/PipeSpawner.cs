using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float maxHeightSpawn;
    [SerializeField] private float minHeightSpawn;
    [SerializeField] private float timeDelaySpawn;
    [SerializeField] private GameObject prefabPipe;
    [SerializeField] private GameObject pipeParent;
    [SerializeField] private GameHandler gameHandler;

    private float _timer;
    private bool _startGame;

    private void OnEnable()
    {
        gameHandler.OnStartGame += StartGame;
    }

    private void OnDisable()
    {
        gameHandler.OnStartGame -= StartGame;
    }

    private void Update()
    {
        DelayBeforeSpawnPipe();
    }

    private void DelayBeforeSpawnPipe()
    {
        if (_startGame == false)
            return;
        
        if (_timer <= 0)
        {
            SpawnPipe();
            _timer = timeDelaySpawn;
        }
        _timer -= Time.deltaTime;
    }
    
    private void SpawnPipe()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, Random.Range(maxHeightSpawn, minHeightSpawn));
        GameObject pipe = Instantiate(prefabPipe,spawnPosition,Quaternion.identity, pipeParent.transform);
        Destroy(pipe,10f);
    }

    private void StartGame(bool starGame)
    {
        _startGame = starGame;
    }
}
