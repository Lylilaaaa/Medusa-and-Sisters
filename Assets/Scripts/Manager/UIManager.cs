using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject PausePanel;
    public GameObject GameOverPanel;

    private void Awake()
    {
        instance = this;
    }

    public void showPausePanel(bool state) 
    {
        
    }

    public void showGameOverPanel(bool state)
    {
        
    }
}
