using UnityEngine;

namespace ScriptableObjectGen
{
    [CreateAssetMenu(fileName = "New Monster",menuName = "Monster")]
    public class Monsters : ScriptableObject
    {
        public string monName;
        
        //data
        public int damage;
        public float maxHealth;
        public float curHealth;
        
        public float movingSpeed;
        public float lockDistance;
        
        //settings
        public GameObject monsterPrefab;
        public bool isChasing;
        public bool isDead;
    }
}