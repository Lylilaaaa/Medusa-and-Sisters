using UnityEngine;
using UnityEngine.UI;
using ScriptableObjectGen;

namespace UI_
{
    public class MonsterHealthBar : MonoBehaviour
    {
        public Monsters CurMons;
        public Slider HealthBar;
        
        private void Update()
        {
            float tarValue = CurMons.curHealth / CurMons.maxHealth;
            HealthBar.value = Mathf.Lerp(HealthBar.value, tarValue, Time.deltaTime * 4f);
        }
    }
}