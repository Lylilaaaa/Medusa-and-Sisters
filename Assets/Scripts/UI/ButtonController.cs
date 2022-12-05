using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private GameObject StartPanel;
    [SerializeField] private GameObject ModeSelectPanel;
    [SerializeField] private GameObject LevelSelectPanel;
    [SerializeField] private GameObject SettingPanel;
    [SerializeField] private GameObject InputSettingPanel;
    
    
    public void CloseStartPanel()
    {
        StartPanel.SetActive(false);
    }
    public void OpenModeSelectPanel()
    {
        ModeSelectPanel.SetActive(true);
    }
    
    public void CloseModeSelectPanel()
    {
        ModeSelectPanel.SetActive(false);
    }
    public void OpenLevelSelectPanel()
    {
        LevelSelectPanel.SetActive(true);
    }
    
    public void CloseLevelSelectPanel()
    {
        LevelSelectPanel.SetActive(false);
    }
    public void OpenInputSettingPanel()
    {
        InputSettingPanel.SetActive(true);
    }
    
    public void CloseInputSettingPanel()
    {
        InputSettingPanel.SetActive(false);
    }
    public void OpenSettingPanelPanel()
    {
        InputSettingPanel.SetActive(true);
    }
    
    public void CloseSettingPanelPanel()
    {
        InputSettingPanel.SetActive(false);
    }
}
