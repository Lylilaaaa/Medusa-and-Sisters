using Manager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject PausePanel;
    public GameObject SettingPanel;
    public GameObject GameOverPanel;

    private void Awake()
    {
        instance = this;
        PausePanel.SetActive(false);
        SettingPanel.SetActive(false);
        GameOverPanel.SetActive(false);
    }

    public void showPausePanel(bool state) 
    {
        PausePanel.SetActive(state);
    }
    
    public void showSettingPanel(bool state)
    {
        SettingPanel.SetActive(state);
    }

    public void showGameOverPanel(bool state)
    {
        GameOverPanel.SetActive(state);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void ResetTime()
    {
        Time.timeScale = 1;
        GameManager.instance.GameState = GameState.Go;
    }
}
