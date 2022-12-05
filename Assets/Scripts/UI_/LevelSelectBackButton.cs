using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectBackButton : MonoBehaviour
{
    public GameObject SelectPanel;

    public void OnPressed() 
    {
        //return back
        SelectPanel.SetActive(false);

    }
}
