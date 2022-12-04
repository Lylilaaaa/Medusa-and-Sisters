using System;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectGen;

public class EnemySpawnManager : MonoBehaviour
{
    [Header("===== Default Setting =====")]
    public static EnemySpawnManager instance;
    public Transform MonsterSpawnPtParent;
    public List<Monsters> MonsterTypeList;
    public SubLevels CurrentLevel;

    [Header("===== Not Setting =====")]
    public List<GameObject> MonsterPool;
    
    private List<Transform> spawnLocation;
    private float timeCounter;

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
        MonsterPool = new List<GameObject>();
        spawnLocation = new List<Transform>();

    }

    private void Start()
    {
        foreach (Transform spt in spawnLocation)
        {
            spawnLocation.Add(spt);
        }
        timeCounter = 0f;
        //DefaultSpawning();
    }

    private void FixedUpdate()
    {
        timeCounter += Time.fixedDeltaTime;
    }

    private void DefaultSpawning()
    {
        //settings about "spawn to pool" according to sub levels scriptable object;
        //ToDo
        //Create random time seed, e.g. there are 4 spawn points, normalMonster is (4, 5, 6, 2), which means there are 4 monsters at the 1st 
        //spawning point etc. They will appear one by one at time 'level time/4, level time/4*2, level time/4*3, level time/4*4'.
        SpawnToPool(0,0,20f);
    }

    private void SpawnToPool(int spawnPointIndex, int monsterTypeIndex, float spawnTime)
    {
        GameObject newMonster = Instantiate(MonsterTypeList[monsterTypeIndex].monsterPrefab,
            spawnLocation[spawnPointIndex].position, spawnLocation[spawnPointIndex].rotation, MonsterSpawnPtParent);
        MonsterPool.Add(newMonster);
    }

    private void DetectClear()
    {
        if (MonsterPool.Count == 0) 
        {
            // wave clear

            // 
        }
    }

    public void RemoveFromPool(string MonsterName)
    {
        for (int i = 0; i < MonsterPool.Count; i++)
        {
            if (MonsterPool[i].name == MonsterName)
            {   
                MonsterPool.RemoveAt(i);
            }
        }
    }
}
