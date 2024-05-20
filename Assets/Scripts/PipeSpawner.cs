using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float MaxHeightSpawn;
    [SerializeField] private float MinHeightSpawn;
    [SerializeField] private float TimeDelaySpawn;
    [SerializeField] private GameObject PrefabPipe;
    [SerializeField] private GameObject PipeParent;

    private float _timer;
    private void Start()
    {
        _timer = TimeDelaySpawn;
        SpawnPipe();
    }

    private void Update()
    {
        if (_timer <= 0)
        {
            SpawnPipe();
            _timer = TimeDelaySpawn;
        }

        _timer -= Time.deltaTime;
    }

    private void SpawnPipe()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, Random.Range(MaxHeightSpawn, MinHeightSpawn));
        GameObject pipe = Instantiate(PrefabPipe,spawnPosition,Quaternion.identity, PipeParent.transform);
        Destroy(pipe,10f);
    }
}
