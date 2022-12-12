using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavePoints : MonoBehaviour
{
    public static Transform[]points;
    void Awake()
    {
        points=new Transform[transform.childCount];//生成路径点列表
        
        for (int i=0;i<points.Length;i++)
        {
            points[i]=transform.GetChild(i);
            Debug.Log(transform.GetChild(i));
        }
        
       
    
        Debug.Log(points);
    }
}
