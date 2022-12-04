using UnityEngine;
namespace ScriptableObjectGen
{
    [CreateAssetMenu(fileName = "New Avatar",menuName = "Avatar")]
    public class Avatars: ScriptableObject
    {
        public string avatarName;
        
        //data
        public float maxHealth;
        public float curHealth;
        
        //ability
        public int damage;
        public float[] combo1Damage = new float[3];

        public bool isDead;
    }
}