using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Start,
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

                case GameState.Pause:
                    PauseTriggered();
                    break;

                case GameState.Over:

                    Debug.Log("游戏结束");

                    //下一局
                    GameOver();
                    break;
            }
        }
    }

    private void Awake()
    {
        instance = this;
        GameState = GameState.Start;
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

        //show up the pause panel
        UIManager.instance.showPausePanel(true);
    }

    private void GameStart()
    {
        //加载场景后，开始初始化

        // 初始化人物位置 与 各项属性 (能力是否跨关卡继承)


        // 初始化怪物位置


        //（初始化宝箱掉落物）
    }


}
