using UnityEngine.SceneManagement;
using UnityEngine;
// using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [Header(" ===== UI Panels ===== ")]
    [SerializeField] private GameObject LOGOPanel;
    [SerializeField] private GameObject StartPanel;
    [SerializeField] private GameObject ModeSelectPanel;
    [SerializeField] private GameObject LevelSelectPanel;
    [SerializeField] private GameObject SettingPanel;
    [SerializeField] private GameObject InputSettingPanel;
    
    [Header(" ===== Player Models ===== ")]
    [SerializeField] private GameObject Medusa;
    [SerializeField] private GameObject Stheno;


    private void Start()
    {
        LOGOPanel.SetActive(true);
        StartPanel.SetActive(false);
        ModeSelectPanel.SetActive(false);
        LevelSelectPanel.SetActive(false);
        SettingPanel.SetActive(false);
        InputSettingPanel.SetActive(false);
    }

    public void OpenStartPanel()
    {
        StartPanel.SetActive(true);
    }
    public void CloseStartPanel()
    {
        StartPanel.SetActive(false);
    }

    public void QuitGameApplication()
    {
        Stheno.GetComponent<Animator>().SetBool("isStartHub",false);
        Medusa.GetComponent<Animator>().SetBool("isStartHub",false);
        Application.Quit();
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
        SettingPanel.SetActive(true);
    }
    
    public void CloseSettingPanelPanel()
    {
        SettingPanel.SetActive(false);
    }

    public void LoadFirstScene_()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadSeCondScene_()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadThirdScene_()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadFourthScene_()
    {
        SceneManager.LoadScene(4);
    }
    public void LoadFifthScene_()
    {
        SceneManager.LoadScene(5);
    }
}
