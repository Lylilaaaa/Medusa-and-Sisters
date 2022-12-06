using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    
    //list to store skill used in kill certain elite enemy
    List<int> TerminateSkillList;
    public int EliteEnemyNumber;

    private void Start()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        TerminateSkillList = new List<int>(EliteEnemyNumber);
    }

    
    /// <summary>
    /// public function used to add dead Elite information 
    /// </summary>
    /// <param name="enemyID"></param>
    /// <param name="TerminateSkill"></param>
    public void AddList(int enemyID, int TerminateSkill)
    {
        if (enemyID > EliteEnemyNumber - 1)
        {
            Debug.LogError("TerminateSkill out of range");
            return;
        }

        TerminateSkillList[enemyID] = TerminateSkill;
    }
}
