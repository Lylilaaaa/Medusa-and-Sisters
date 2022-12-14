using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public enum GameState
{
    Start,
    Go,
    Over,
    Pause
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private GameState gameState;

    public GameState GameState
    {
        get => gameState;
        set
        {
            gameState = value;
            switch (gameState)
            {
                case GameState.Start:

                    GameStart();
                    //GameState = GameState.Selecting_map;
                    break;
                
                case GameState.Go:
                    GameGo();
                    break;

                case GameState.Pause:
                    PauseTriggered();
                    break;

                case GameState.Over:

                    Debug.Log("试试");

                    //��һ��
                    GameOver();
                    break;
            }
        }
    }

    private void Awake()
    {
        instance = this;
        GameState = GameState.Start;
        //GameManager.instance.gameState = GameState.Pause;
    }

    private void GameGo()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void GameOver()
    {
        //
        Time.timeScale = 0;
        
        //show up the gameover panel
        UIManager.instance.showGameOverPanel(true);
    }

    private void PauseTriggered()
    {
        //time freeze, will be recover at the UI button part
        Time.timeScale = 0;
        
        Cursor.lockState = CursorLockMode.None;

        //show up the pause panel
        UIManager.instance.showPausePanel(true);
    }

    private void GameStart()
    {
        //���س����󣬿�ʼ��ʼ��

        // ��ʼ������λ�� �� �������� (�����Ƿ��ؿ��̳�)


        // ��ʼ������λ��


        //����ʼ����������
    }


}
