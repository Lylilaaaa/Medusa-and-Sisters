using System;
using UnityEngine;

namespace UI
{
    public class ClickAnyWhere_LOGO : MonoBehaviour

    {
        [SerializeField] private GameObject LOGOPanel;
        [SerializeField] private GameObject StartPanel;
        
        public bool GamehasStart = false;
        public void Update()
        {
            if (Input.anyKeyDown && GamehasStart == false)
            {
                GamehasStart = true;
                LOGOPanel.SetActive(false);
                StartPanel.SetActive(true);
            }
        }
    }
}