using UnityEngine;

namespace ScriptableObjectGen
{
    [CreateAssetMenu(fileName = "New Level",menuName = "SubLevel")]
    public class SubLevels : ScriptableObject
    {
        public string levelName;
        
        //data
        public Vector2 worldRange;
        public int levelTime;
        public int attackMonsterAmount;
        public int speedMonsterAmount;
        public int thickMonsterAmount;
        public int normalMonsterAmount;

        //settings

    }
}