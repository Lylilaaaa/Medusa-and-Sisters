using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public static EnemySpawnManager instance;
    public Transform[] SpawnLocation;
    List<GameObject> EnemyPool;

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        DetectClear();
    }

    private void Init()
    {
        instance = this;
        EnemyPool = new List<GameObject>();
    }

    private void DetectClear()
    {
        if (EnemyPool.Count == 0) 
        {
            // wave clear

            // 
        }
    }
}
