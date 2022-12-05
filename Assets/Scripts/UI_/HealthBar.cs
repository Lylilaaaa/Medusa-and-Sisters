using System;
using UnityEngine;
using UnityEngine.UI;
using ScriptableObjectGen;
namespace UI_
{
    public class HealthBar : MonoBehaviour
    {
        public Avatars CurAvatars;

        public Slider HealthBar_; 
        
        private void Update()
        {
            float tarValue = CurAvatars.curHealth / CurAvatars.maxHealth;
            HealthBar_.value = Mathf.Lerp(HealthBar_.value, tarValue, Time.deltaTime * 4f);
        }
    }
}