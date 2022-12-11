using System;
using UnityEngine; 
using UnityEngine.UI; 
using ScriptableObjectGen;

namespace Manager
{
    public class LevelManager : MonoBehaviour
    {
        public Text levelTimer;
        public SubLevels curLevel;

        private float curTimer;

        private void Start()
        {
            levelTimer.text = curLevel.levelTime.ToString();
            curTimer = curLevel.levelTime;
        }

        private void FixedUpdate()
        {
            curTimer -= Time.fixedDeltaTime;
            levelTimer.text = Math.Floor(curTimer).ToString();
        }
    }
}