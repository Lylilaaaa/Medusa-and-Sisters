using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.SceneManagement;

public class GameStartButtonController : MonoBehaviour
{
    [SerializeField] private GameObject LevelSelectPanel;
    
    public void onPressed()
    {
        LevelSelectPanel.SetActive(true);
    }
}
