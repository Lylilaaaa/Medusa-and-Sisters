using UnityEngine;

namespace ScriptableObjectGen
{
    [CreateAssetMenu(fileName = "New Monster",menuName = "Monster")]
    public class Monsters : ScriptableObject
    {
        public string monName;
        
        //data
        public float maxHealth;
        public float curHealth;
        
        //ability
        public int damage;
        public float movingSpeed;
        public float lockDistance;
        public float attackInterval;
        public float attackDistance;
        public float leastDistance;
        
        //settings
        public GameObject monsterPrefab;

        //state
        public bool isChasing;
        public bool isDead;
    }
}